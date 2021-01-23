    public MessageTypes MessageType
    {
        get { return _messageType; }
        set
        {
            _messageType = value;
            RaisePropertyChanged(() => MessageType);
        }
    }
