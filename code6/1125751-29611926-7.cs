        public async Task InitialLoad()
        {
            await Task.Delay(5000).ConfigureAwait(false);
            this.Value = "Loaded";
        }
        public Waiter()
        {
            this.Value = "Loading data";
            InitialLoad().Wait();
        }
