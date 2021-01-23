    private NflGameStatus _selectedGame;
    public NflGameStatus SelectedGame
    {
        get
        {
            return _selectedGame;
        }
        set
        {
            _selectedGame = value;
            RaisePropertyChanged("SelectedGame");
        }
    }
