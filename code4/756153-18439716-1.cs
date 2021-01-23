    public class VideoInfo : INotifyPropertyChanged
    {
        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                NotifyPropertyChanged("IsSelected");
            }
        }
        private string thumnailUrl;
        public string ThumnailUrl
        {
            get { return thumnailUrl; }
            set
            {
                thumnailUrl = value;
                NotifyPropertyChanged("ThumnailUrl");
            }
        }
        private string videoName;
        public string VideoName
        {
            get { return videoName; }
            set
            {
                videoName = value;
                NotifyPropertyChanged("VideoName");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
