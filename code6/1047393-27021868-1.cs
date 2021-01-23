    class Worker
    {
        public static int threadCount { get; set; }
        Task[] tasks;
        //ex data
        public static string exception;
        static CancellationTokenSource wtoken = new CancellationTokenSource();
        CancellationToken cancellationToken = wtoken.Token;
        public void doWork(ParameterizedThreadStart method)
        {
            try
            {
                tasks = Enumerable.Range(0, 4).Select(i => Task.Factory.StartNew(() =>
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        method(i);
                    }
                }, cancellationToken)).ToArray();
            }
            catch (Exception ex) { exception = ex.Message; }
        }
        public void HardStop()
        {
            try
            {
                using (wtoken)
                {
                  wtoken.Cancel();
                }
                wtoken = null;
                tasks = null;
            }
            catch (Exception ex) { exception = ex.Message; }
        }
    }
