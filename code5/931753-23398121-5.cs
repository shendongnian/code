        private string _statusText;
        public string StatusText
        {
            [DebuggerStepThrough]
            get { return _statusText; }
            [DebuggerStepThrough]
            set
            {
                if (value != _statusText)
                {
                    _statusText = value;
                    OnPropertyChanged("StatusText");
                }
            }
        }
