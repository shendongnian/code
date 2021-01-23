    public partial class MainWindow : Window, INotifyPropertyChanged {
        private bool m_IsTextBlockVisible = true;
        public bool IsTextBlockVisible {
            get { return m_IsTextBlockVisible; }
            set { m_IsTextBlockVisible = value; NotifyPropertyChanged("IsTextBlockVisible"); }
        }
        public MainWindow() {
            InitializeComponent();
            DataContext = this;
        }
        private void ToggleItButton_Click(object sender, RoutedEventArgs e) {
            IsTextBlockVisible = !IsTextBlockVisible;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string name) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
