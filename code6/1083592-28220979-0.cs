    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Visibility _gird2Visibility;
        public Visibility Grid2Visibility
        {
            get { return _gird2Visibility; }
            set
            {
                _gird2Visibility = value;
                OnPropertyChanged("Grid2Visibility");
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            Grid2Visibility = Visibility.Hidden;
        }
        private void Grid1_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
           Grid2Visibility = Visibility.Visible;
        }
        private void Grid1_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            Grid2Visibility = Visibility.Hidden;
        }
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
    
