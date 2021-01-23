    public sealed class MyClass
    {
        // this should be called from inside
        private void OnSomeEvent()
        {
            var handler = SomeEvent;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    
        // this should be called from outside
        public void RaiseSomeEvent()
        {
            OnSomeEvent(); 
        }
        
        public event EventHandler SomeEvent;
        // other code here...
    }
