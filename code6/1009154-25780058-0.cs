    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        // implement the INotify
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private string _mytext;
        public String MyText
        {
            get { return _mytext;  }
            set { _mytext = value; NotifyPropertyChanged("MyText"); }
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;             // set the datacontext to itself :)
            MyText = "Change Me";
        }
    }
----------
    <TextBlock Text="{Binding MyText}" Foreground="White" Background="Black"></TextBlock>
