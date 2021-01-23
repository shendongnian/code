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
            _stream.Close();
            _writerTask.Wait();
        }
        private void writerTask()
        {
            foreach (var data in _queue.GetConsumingEnumerable())
                _stream.Write(data, 0, data.Length);
        }
        private readonly Task _writerTask;
        private readonly BlockingCollection<byte[]> _queue;
        private readonly FileStream _stream;
    }
