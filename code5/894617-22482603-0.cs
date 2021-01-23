    public static class SynchronizedWorker
    {
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);
        public static void ProcessTask(Action task)
        {
            if (waitHandle.WaitOne())
            {
                Task.Factory.StartNew((() =>
                {
                    // process task
                    task();
                    // signal that we are done
                    waitHandle.Set();
                }));
            }
        }
    }
