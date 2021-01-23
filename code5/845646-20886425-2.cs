    class TestSynchronizationContext : SynchronizationContext
    {
        public bool PostCalled { get; private set; }
        
        public override void Post(SendOrPostCallback d, object state)
        {
            PostCalled = true;
            base.Post(d, state);
        }
        
        public void Reset()
        {
            PostCalled = false;
        }
    }
