    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private bool _isExpandedMode;
        private Visibility _compactVisibility;
        //Set this to change the mode of the Window
        public bool IsExpandedMode
        {
            get { return _isExpandedMode; }
            set
            {
                _isExpandedMode = value;
                OnPropertyChanged();
                OnPropertyChanged("ExpandedVisibility");
                OnPropertyChanged("CompactVisibility");
            }
        }
        //One way property for getting whether the the visibility for expanded controls
        public Visibility ExpandedVisibility
        {
            get { return IsExpandedMode ? Visibility.Visible : Visibility.Collapsed; }
        }
        //One way property for getting whether the the visibility for compact controls
        public Visibility CompactVisibility
        {
            get { return !IsExpandedMode ? Visibility.Visible : Visibility.Collapsed; }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.IsExpandedMode = true;
            this.DataContext = this;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IsExpandedMode = !IsExpandedMode;
        }
    }
