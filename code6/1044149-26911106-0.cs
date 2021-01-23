     public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private object value;        
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            DataContext = this;
        }
        public object Value
        {
            get { return value; }
            set
            {                
                this.value = value;
                NotifyPropertyChanged("Value");
            }
        }       
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Value = true;            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
