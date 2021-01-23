    class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
        }
        private Visibility _vis = Visibility.Collapsed;
        public Visibility Vis
        {
            get { return _vis; }
            set
            {
                _vis = value;
                RaisePropertyChanged("Vis");
            }
        }
    }
