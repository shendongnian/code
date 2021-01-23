        public async void Index()
        {
            await InitializeIndexAsync();
        }
        private Task InitializeIndexAsync()
        {
            return Task.Factory.StartNew(() => InitializeIndex());
        }
        private void InitializeIndex()
        {
            State = IndexState.Initializing;
            // Initialize other things synchronously.
            
            State = IndexState.Ready;
        }
