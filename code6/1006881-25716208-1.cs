    using System.ComponentModel;   // INotifyPropertyChanged
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        private string _apiinfotext = "Default Text";
        public string APIinfotext 
        {
            get { return _apiinfotext; }
            set
            {
                _apiinfotext = value;
                RaisePropertyChanged("APIinfotext");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        
        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }
        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            this.APIinfotext = "Don't confuse movement for progress.";
        }
    }
