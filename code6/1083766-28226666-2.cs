    class PlayerManagementViewModel : BindableBase
    {
        private Player _selectedPlayer;
        private readonly DelegateCommand _deletePlayerCommand;
        public PlayerManagementViewModel(...)
        {
            _deletePlayerCommand = new DelegateCommand(() => DeleteSelectedPlayer(), () => SelectedPlayer != null);
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
                SetProperty(ref _selectedPlayer, value);
                OnPropertyChanged(() => FormattedPlayerStatus);
                _deletePlayerCommand.RaiseCanExecuteChanged();
            }
        }
    }
