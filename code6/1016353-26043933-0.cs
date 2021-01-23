    class ViewModel
    {
        // default value just to avoid a null check
        private CancellationTokenSource intializationCancellation =
            new CancellationTokenSource();
    
        public async Task InitializeAsync(int parameter)
        {
            // cancel previous initialization, if any
            intializationCancellation.Cancel();
        
            var cts = new CancellationTokenSource();
            intializationCancellation = cts;
            
            var value = await GetValueaAsync(parameter);
            
            if (cts.Token.IsCancellationRequested)
                return;
                
            Value = value;
        }
        
        private async Task<string> GetValueAsync(int parameter)
        {
            // call the external service here
        }
    
        public string Value { get; private set; }
    }
