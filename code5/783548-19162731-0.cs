    class MessageEventArgs : EventArgs
    {
        private int _pId;
        private string _message;
        private string _channelPath;
        public MessageEventArgs(string message)
        {
            _pId = Process.GetCurrentProcess().Id;
            _message = message;
            _channelPath = null;
        }
        public MessageEventArgs(string[] details)
        {
            if (details.Length == 1)
            {
                _pId = Process.GetCurrentProcess().Id;
                _message = details[0];
                _channelPath = null;
                return;
            }
            _pId = int.Parse(details[0]);
            _message = details[1];
            _channelPath = details[2];
        }
    }
