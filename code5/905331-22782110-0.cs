    public class ActivityLog : INotifyPropertyChanged
    {
        public string strLogID { get; set; } //unique id for the log entry.
        private string _strLogDate;
        public string strLogDate
        {
            get
            {
                return _strLogDate;
            }
            set
            {
                _strLogDate = value;
                RaisePropertyChanged("strLogDate");
            }
        }
        public bool booIsUploaded { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
