     public partial class Window2 : Window, IHomeVisibility,INotifyPropertyChanged
    {
        public Window2()
        {
            InitializeComponent();
            HomeVisibility = Visibility.Collapsed;
        }
        private Visibility homeVisibility;
        public Visibility HomeVisibility
        {
            get { return homeVisibility; }
            set { homeVisibility = value; OnPropertyChanged("HomeVisibility"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frm.Navigate(new Login(this));
        }
        
    }
