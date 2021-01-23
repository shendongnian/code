    class SessionManager
    {
        private ServiceProvider _serviceProvider;
        public int SessionId
        {
            get;
            private set;
        }
        public Task<bool> StartUp(Object param)
        {
            _serviceProvider = new ServiceProvider();
            var tcs = new TaskCompletionSource<bool>();
            _serviceProvider.OnStartApplicationSessionResponse += (sender, args) =>
            {
                // do your stuff
                // e.g.
                SessionId = 0xB00B5;
                tcs.SetResult(true);
            };
            _serviceProvider.startUp(param);
            return tcs.Task;
        }
    }
