        public partial class EmailContentsTemplate : UserControl, INotifyPropertyChanged
    {
        private Email _email;
        public Email Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }
        
        public EmailContentsTemplate()
        {
            InitializeComponent();
            DataContext = this;
            Binding myBinding = new Binding("Email.Subject");
            myBinding.Source = this;
            tbSubject.SetBinding(TextBlock.TextProperty, myBinding);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }
    }
