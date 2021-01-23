    class User : INotifyPropertyChanged
    {
        private string sender = string.Empty;
        private string receiver = string.Empty;
        private string senderVisibility = string.Empty;
        private string receiverVisibility = string.Empty;
        public string Sender
        {
            get
            {
                return sender;
            }
            set
            {
                if (value != this.sender)
                {
                    this.sender = value;
                    NotifyPropertyChanged("Sender");
                }
            }
        }
        public string Receiver
        {
            get
            {
                return this.receiver;
            }
            set
            {
                if (value != this.receiver)
                {
                    this.receiver = value;
                    NotifyPropertyChanged("Receiver");
                }
            }
        }
        public string ReceiverVisibility
        {
            get
            {
                return this.receiverVisibility;
            }
            set
            {
                if (value != this.receiverVisibility)
                {
                    this.receiverVisibility = value;
                    NotifyPropertyChanged("ReceiverVisibility");
                }
            }
        }
        public string SenderVisibility
        {
            get
            {
                return this.senderVisibility;
            }
            set
            {
                if (value != this.senderVisibility)
                {
                    this.senderVisibility = value;
                    NotifyPropertyChanged("SenderVisibility");
                }
            }
        }
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
