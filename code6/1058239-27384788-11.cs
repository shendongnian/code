        private CancellationTokenSource tokenSource;
        private Task backgroundTask;
        protected override void OnStart(string[] args)
        {
            tokenSource = new CancellationTokenSource();
            var cancellation = tokenSource.Token;
            backgroundTask = Task.Factory.StartNew(() => WorkerThreadFunc(cancellation),
                                        cancellation,
                                        TaskCreationOptions.LongRunning,
                                        TaskScheduler.Default);
        }
