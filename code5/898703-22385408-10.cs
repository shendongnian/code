    private RelayCommand closeApplicationCommand;
    public RelayCommand CloseApplicationCommand
    {
        get
        {
            return closeApplicationCommand ?? (closeApplicationCommand =
                new RelayCommand(o => this.CloseApplication(), o => CanCloseApplication));
        }
    }
