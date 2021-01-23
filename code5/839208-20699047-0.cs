    public partial class MainWindow : Window,INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static object mySharedVariableToOtherClass = value;
        private object _selectedItem;
        public object SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                mySharedVariableToOtherClass = null;
                OnPropertyChanged("SelectedItem");
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            SelectedItem = "vimal";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SelectedItem = null;
        }
        public void OnPropertyChanged(string PropertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(PropertyName));    
            }
        }
    }
