    public partial class UserControl1 : UserControl, INotifyPropertyChanged
    {
        private string _versionNumber;
        private ImageSource _backgroundImage;
        public UserControl1()
        {
            InitializeComponent();
        }
        public string VersionNumber
        {
            private get { return _versionNumber; }
            set
            {
                _versionNumber = value;
                OnPropertyChanged("VersionNumber");
            }
        }
        public ImageSource BackgroundImage
        {
            get { return _backgroundImage; }
            set
            {
                _backgroundImage = value;
                OnPropertyChanged("BackgroundImage");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
