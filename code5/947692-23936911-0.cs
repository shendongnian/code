    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Video> Videos { get; set; }
        public ObservableCollection<Video> FavoriteVideos { get; set; }
        public MainViewModel()
        {
            Videos = new ObservableCollection<Video>();
            FavoriteVideos = new ObservableCollection<Video>();
        }
        private Video selectedVideo;
        public Video SelectedVideo
        {
            get { return selectedVideo; }
            set { selectedVideo = value; NotifyPropertyChanged("SelectedVideo"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
