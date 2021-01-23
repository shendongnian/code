    public class SomeClass
    {
        private bool _isConnected;
        private bool _isBusy;
        public event EventHandler SomeCustomEvent;
        public bool IsConnected
        {
            get { return _isConnected; }
            set
            {
                _isConnected = value;
                CheckAndCallHandlers();
            }
        }
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                CheckAndCallHandlers();
            }
        }
        private void CheckAndCallHandlers()
        {
            var handler = SomeCustomEvent;
            if(IsConnected && IsBusy && handler != null)
                handler(this, EventArgs.Empty);
        }
    }
