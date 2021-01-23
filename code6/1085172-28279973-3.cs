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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
          if (UrlBox.Text.Contains("something"))
          {
            var mapper = new TeamMapper();
            TeamList = new ObservableCollection<Team>    (mapper.MapTeams(UrlBox.Text));
         }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
