    public class StackOverflowMonitorExample
    {
        ConcurrentQueue<Tick> _tickQueue = new ConcurrentQueue<Tick>();
        object locker = new object();
        bool stopCondition = false;
        public void Load(Tick tick)
        {
            _tickQueue.Enqueue(tick);
            lock (locker)
            {
                Monitor.Pulse(locker);
            }
        }
        private void Unload()
        {
            while (!stopCondition)
            {
                try
                {
                    Tick nextWorkItem = null;
                    _tickQueue.TryDequeue(out nextWorkItem);
                    if (nextWorkItem != null)
                    {
                        Persist(nextWorkItem);
                    }
                    else
                    {
                        lock (locker)
                        {
                            Monitor.Wait(locker);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
