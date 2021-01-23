    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    
    /// <summary>
    /// Acts as a container for concurrent read/write flushing (for example, parsing a
    /// file while concurrently uploading the contents); supports any number of concurrent
    /// writers and readers, but note that each item will only be returned once (and once
    /// fetched, is discarded). It is necessary to Close() the bucket after adding the last
    /// of the data, otherwise any iterators will never finish
    /// </summary>
    class ThreadSafeBucket<T> : IEnumerable<T>
    {
        private readonly Queue<T> queue = new Queue<T>();
    
        public void Add(T value)
        {
            lock (queue)
            {
                if (closed) // no more data once closed
                    throw new InvalidOperationException("The bucket has been marked as closed");
    
                queue.Enqueue(value);
                if (queue.Count == 1)
                { // someone may be waiting for data
                    Monitor.PulseAll(queue);
                }
            }
        }
    
        public void Close()
        {
            lock (queue)
            {
                closed = true;
                Monitor.PulseAll(queue);
            }
        }
        private bool closed;
    
        public IEnumerator<T> GetEnumerator()
        {
            while (true)
            {
                T value;
                lock (queue)
                {
                    if (queue.Count == 0)
                    {
                        // no data; should we expect any?
                        if (closed) yield break; // nothing more ever coming
    
                        // else wait to be woken, and redo from start
                        Monitor.Wait(queue);
                        continue;
                    }
                    value = queue.Dequeue();
                }
                // yield it **outside** of the lock
                yield return value;
            }
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    static class Program
    {
        static void Main()
        {
            var bucket = new ThreadSafeBucket<int>();
            int expectedTotal = 0;
            ThreadPool.QueueUserWorkItem(delegate
            {
                int count = 0, sum = 0;
                foreach(var item in bucket)
                {
                    count++;
                    sum += item;
                    if ((count % 100) == 0)
                        Console.WriteLine("After {0}: {1}", count, sum);
                }
                Console.WriteLine("Total over {0}: {1}", count, sum);
            });
            Parallel.For(0, 5000,
                new ParallelOptions { MaxDegreeOfParallelism = 3 },
                i => {
                    bucket.Add(i);
                    Interlocked.Add(ref expectedTotal, i);
                }
            );
            Console.WriteLine("all data added; closing bucket");
            bucket.Close();
            Thread.Sleep(100);
            Console.WriteLine("expecting total: {0}",
                Interlocked.CompareExchange(ref expectedTotal, 0, 0));
            Console.ReadLine();
            
    
        }
        
    }
