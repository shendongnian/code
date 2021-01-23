       public async Task<String> Get1()
        {
            await Task.Delay(2000).ConfigureAwait(false);            
            return "Got value 1";
        }
        
        public async Task<String> Get2()
        {
            await Task.Delay(3000).ConfigureAwait(false);
            return "Got value 2";
        }
        public async Task InitialLoad()
        {          
            this.Value = "Loading started";
            
            var tasks = new Task[]
            {
                Get1().ContinueWith(
                    (prev) => 
                        this.Value1 = prev.Result),
                Get2().ContinueWith(
                    (prev) => 
                        this.Value2 = prev.Result)
            };
            
            await Task.WhenAll(tasks).ConfigureAwait(false);
            this.Value = "Loaded";
        }
        public Waiter()
        {
            InitialLoad().Wait();
        }
