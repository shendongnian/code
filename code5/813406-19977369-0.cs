        private ManualResetEventSlim processingAllowedEvent =
            new ManualResetEventSlim(true);
        public bool ProcessingAllowed
        {
            get
            {
                return processingAllowedEvent.IsSet;
            }
            set
            {
                if (value)
                    processingAllowedEvent.Set();
                else
                    processingAllowedEvent.Reset();
            }
        }
        public void WaitUntilProcessingAllowed()
        {
            processingAllowedEvent.Wait();
        }
