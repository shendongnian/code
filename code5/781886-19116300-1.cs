        public event EventHandler Disconnected;
        protected virtual void OnDisconnected()
        {
            EventHandler handler = Disconnected;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        private bool _isconnected;
        public bool IsConnected
        {
            get
            {
                return _isconnected;
            }
            private set
            {
                if (!value && _isConnected)
                {
                    OnDisconnected();
                }
                _isconnected = value;
            }
        }
        #region Methods
        public void Connect()
        {
            //TODO implement code to connect
            IsConnected = true;
        }
        public void Disconnect()
        {
            //TODO implement code to connect
            IsConnected = false;
        }
        #endregion Methods
