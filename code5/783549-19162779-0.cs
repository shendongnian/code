    class MessageEventArgs : EventArgs
    {
        private int _pId;
        private string _message;
        private string _channelPath;
        public MessageEventArgs(string message)
        {
            Initialize( message );
        }
        public MessageEventArgs(string[] details)
        {
            if (details.Length == 1)
            {
                Initialize( details[ 0 ] );
                return;
            }
            _pId = int.Parse(details[0]);
            _message = details[1];
            _channelPath = details[2];
        }
    
        private void Initialize(string message)
        {
            _pId = Process.GetCurrentProcess().Id;
            _message = message;
            _channelPath = null;     
        }
    }
