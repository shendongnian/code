    private readonly DelegateCommand _deletePlayerCommand;
    public PlayerManagementViewModel(...)
    {
        _deletePlayerCommand = new DelegateCommand(() => this.DeleteSelectedPlayer(), () => SelectedPlayer != null);
    }
    public ICommand DeletePlayerCommand
    {
        get { return _deletePlayerCommand; }
    }
    
    public Player SelectedPlayer
    {
        get { return _selectedPlayer; }
        set
        {
            SetProperty(ref this._selectedPlayer, value);
            this.OnPropertyChanged(() => this.FormattedPlayerStatus);
            this.OnPropertyChanged(() => this.SelectedPlayer);
            _deletePlayerCommand.RaiseCanExecuteChanged();
        }
    }
