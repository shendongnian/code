    public class InsertMatchVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string home, away, bet;
        public Match newMatch = new Match();
        public string Home
        {
            set
            {
                home = value;
                OnPropertyChanged("Home");
                newMatch.HomeTeam = home;
            }
            get
            {
                return home;
            }
        }
        public string Away
        {
            set
            {
                away = value;
                OnPropertyChanged("Away");
                newMatch.AwayTeam = away;
            }
            get
            {
                return away;
            }
        }
        public string Bet
        {
            set
            {
                bet = value;
                OnPropertyChanged("Bet");
                newMatch.Bet = bet;
            }
            get
            {
                return bet;
            }
        }       
        public ICommand InsertBet;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
