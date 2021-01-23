    <Button Content="Gönder" HorizontalAlignment="Left" VerticalAlignment="Top" Width="75" Margin="932,23,0,0" Height="25" Command="{Binding Path=SetTeamsCommand }" CommandParameter="{Binding ElementName=UrlBox, Path=Text}"/>
    class TeamMappingVM : INotifyPropertyChanged
    {
        public ObservableCollection<Team> TeamList { get; set; }
        public ICommand SetTeamsCommand { get; internal set; }
        private string _url;
        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                NotifyPropertyChanged("Url");
            }
        }
        public void SetTeamList()
        {
            var mapper = new TeamMapper();
            TeamList = new ObservableCollection<Team>(mapper.MapTeams(Url));
        }
        public bool CanParseTeams()
        {
            return !string.IsNullOrEmpty(Url);
        }
        public TeamMappingVM()
        {
            SetTeamsCommand = new RelayCommand(SetTeamList, CanParseTeams);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
