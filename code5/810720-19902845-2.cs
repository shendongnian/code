    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        public sealed class ParallelFileWriter: IDisposable
        {
            // maxQueueSize is the maximum number of buffers you want in the queue at once.
            // If this value is reached, any threads calling Write() will block until there's
            // room in the queue.
            public ParallelFileWriter(string filename, int maxQueueSize)
            {
                _stream     = new FileStream(filename, FileMode.Create);
                _queue      = new BlockingCollection<byte[]>(maxQueueSize);
                _writerTask = Task.Run(() => writerTask());
            }
            public void Write(byte[] data)
            {
                _queue.Add(data);
            }
            public void Dispose()
            {            
                _queue.CompleteAdding();
                _writerTask.Wait();
                _stream.Close();
            }
            private void writerTask()
            {
                foreach (var data in _queue.GetConsumingEnumerable())
                {
                    Debug.WriteLine("Queue size = {0}", _queue.Count);
                    _stream.Write(data, 0, data.Length);
                }
            }
            private readonly Task _writerTask;
            private readonly BlockingCollection<byte[]> _queue;
            private readonly FileStream _stream;
        }
        class Program
        {
            private void run()
            {
                // For demo purposes, cancel after a couple of seconds.
                using (var fileWriter = new ParallelFileWriter(@"C:\TEST\TEST.DATA", 100))
                using (var cancellationSource = new CancellationTokenSource(2000))
                {
                    const int NUM_THREADS = 8;
                    Action[] actions = new Action[NUM_THREADS];
                    for (int i = 0; i < NUM_THREADS; ++i)
                    {
                        int id = i;
                        actions[i] = () => writer(cancellationSource.Token, fileWriter, id);
                    }
                    Parallel.Invoke(actions);
                }
            }
            private void writer(CancellationToken cancellation, ParallelFileWriter fileWriter, int id)
            {
                int index = 0;
                while (!cancellation.IsCancellationRequested)
                {
                    string text = string.Format("{0}:{1}\n", id, index++);
                    byte[] data = Encoding.UTF8.GetBytes(text);
                    fileWriter.Write(data);
                }
            }
            static void Main(string[] args)
            {
                new Program().run();
            }
        }
    }
