     public partial class MainWindow : Window,INotifyPropertyChanged
    { 
        private ObservableCollection<Team> _teamList  ;
        public ObservableCollection<Team> TeamList
        {
            get
            {
                return _teamList;
            }
            set
            {
                if (_teamList == value)
                {
                    return;
                }
                _teamList = value;
                OnPropertyChanged();
            }
        }
    
        public MainWindow()
        {
            InitializeComponent();
          
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
