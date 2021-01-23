        public class ReadWrite
        {
            private static int readerCount = 0;
            private static int writerCount = 0;
            private int pendingReaderCount = 0;
            private int pendingWriterCount = 0;
            private readonly object decision = new object();
            private class WakeLock:IDisposable
            {
                private readonly object wakeLock;
                public WakeLock(object wakeLock) { this.wakeLock = wakeLock; }
                public virtual void Dispose() { lock(this.wakeLock) Monitor.PulseAll(this.wakeLock); }
            }
            private class ReadLock:WakeLock
            {
                public ReadLock(object wakeLock) : base(wakeLock) { Interlocked.Increment(ref readerCount); }
                public override void Dispose()
                {
                    Interlocked.Decrement(ref readerCount);
                    base.Dispose();
                }
            }            
            private class WriteLock:WakeLock
            {
                public WriteLock(object wakeLock) : base(wakeLock) { Interlocked.Increment(ref writerCount); }
                public override void Dispose()
                {
                    Interlocked.Decrement(ref writerCount);
                    base.Dispose();
                }
            }
            
            public IDisposable TakeReadLock()
            {
                lock(decision)
                {
                    pendingReaderCount++;
                    while (pendingWriterCount > 0 || Thread.VolatileRead(ref writerCount) > 0)
                        Monitor.Wait(decision);
                    pendingReaderCount--;
                    return new ReadLock(this.decision);
                }
            }
            public IDisposable TakeWriteLock()
            {
                lock(decision)
                {
                    pendingWriterCount++;
                    while (Thread.VolatileRead(ref readerCount) > 0 || Thread.VolatileRead(ref writerCount) > 0)
                        Monitor.Wait(decision);
                    pendingWriterCount--;
                    return new WriteLock(this.decision);
                }
            }
        }
