    public sealed partial class BlankPage4 : Page, INotifyPropertyChanged
    {
        private Visibility _IsHide;
        public Visibility IsHide
        {
            get { return _IsHide; }
            set
            {
                _IsHide = value;
                OnPropertyChanged("IsHide");
            }
        }
    
        public BlankPage4()
        {
            this.InitializeComponent();
            DataContext = this;
        }
    
        private void btnHideAll_Click(object sender, RoutedEventArgs e)
        {
            IsHide = Visibility.Collapsed;
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
