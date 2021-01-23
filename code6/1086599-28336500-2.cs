        protected async override void OnStart(string[] args)
        {   
            try
            {
                await pollInterval();
            }
            catch (TaskCanceledException) { }
        }
        public async Task pollInterval()
        {
            CancellationToken cancel = cancelToken.Token;
            TimeSpan interval = TimeSpan.FromMinutes(5);
            while (true)
            {
                await Task.Delay(interval, cancel);
                EventLog.WriteEntry("*-HEY MAN I\"M POLLNG HERE!!-*");
                //Polling code goes here. Checks periodically IsCancellationRequested
            }
        }
