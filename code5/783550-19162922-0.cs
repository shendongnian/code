        public MessageEventArgs(string message)
            : this(new [] {message})
        {
        }
        public MessageEventArgs(string[] details)
        {
            if (details.Length == 1)
            {
                _pId = Process.GetCurrentProcess().Id;
                _message = details[0];
                _channelPath = null;
            }
            else
            {
                _pId = int.Parse(details[0]);
                _message = details[1];
                _channelPath = details[2];
            }
        }
