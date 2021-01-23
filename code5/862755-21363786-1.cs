    public class DownloadItem : INotifyPropertyChanged
    {
        public double downloadPercent { get; set; }
        public string episodeTitle { get; set; }
        public string podcastFeedTitle { get; set; }
        public DownloadOperation operation { get; set; }
        private double percent;
        public double Percent
        {
            get { return percent; }
            set
            {
                if (percent == value)
                    return;
                
                percent = value;
                OnPropertyChanged("Percent");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
