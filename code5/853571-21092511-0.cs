    public class Download : INotifyPropertyChanged
    {
        private string _WebsiteTitle;
        public string WebsiteTitle
        {            
            get { return _WebsiteTitle; }
            set
            {
                if (_WebsiteTitle == value)
                    return;
                _WebsiteTitle = value;
                this.OnPropertyChanged("WebsiteTitle");
            }
        }
        private string _Status;
        public string Status
        {
            get { return _Status; }
            set
            {
                if (_Status == value)
                    return;
                _Status = value;
                this.OnPropertyChanged("Status");
            }
        }
        private string _DownloadStartDate;
        public string DownloadStartDate
        {
            get { return _DownloadStartDate; }
            set
            {
                if (_DownloadStartDate == value)
                    return;
                _DownloadStartDate = value;
                this.OnPropertyChanged("DownloadStartDate");
            }
        }
        private string _DownloadingSpeed = "0 kb/s";
        public string DownloadingSpeed
        {
            get { return _DownloadingSpeed; }
            set
            {
                if (_DownloadingSpeed == value)
                    return;
                _DownloadingSpeed = value;
                this.OnPropertyChanged("DownloadingSpeed");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if(this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
