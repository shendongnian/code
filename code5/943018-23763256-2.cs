        private static volatile bool _done;
        private static void Main()
        {
            #region keyboard interrupt
            ThreadPool.QueueUserWorkItem(delegate
            {
                while (!_done)
                {
                    if (!Console.KeyAvailable) continue;
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.Escape:
                            _done = true;
                            break;
                    }
                }
            });
            #endregion
            #region start 3 threads in the pool
            ThreadPool.QueueUserWorkItem(DatabaseWorkerCallback);
            ThreadPool.QueueUserWorkItem(DatabaseWorkerCallback);
            ThreadPool.QueueUserWorkItem(DatabaseWorkerCallback);
            #endregion
            Thread.Sleep(Timeout.Infinite);
        }
        private static void DatabaseWorkerCallback(object state)
        {
            Console.WriteLine("[{0}] Starting", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
            while (!_done)
            {
                using (var dao = new SomeDAO(Properties.Settings.Default.DSN))
                {
                    foreach (var assetVo in dao.DoWork())
                        Console.WriteLine(assetVo);
                }
            }
            Console.WriteLine("[{0}] Stopping", Thread.CurrentThread.ManagedThreadId);
        }
