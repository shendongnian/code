    class Message : INotifyPropertyChanged
    {
        public string MessageText { get; set; }
        private string messageTime = String.Empty;
        public string MessageTime
        {
            get { return this.messageTime; }
            set
            {
                if (value != this.messageTime)
                {
                    this.messageTime = value;
                    NotifyPropertyChanged("MessageTime");
                }
            }
        }
        public DateTime MessageDateTime { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
