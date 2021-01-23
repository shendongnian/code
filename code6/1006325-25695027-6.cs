    private ICommand startCommand;
    public ICommand StartTCommand
    {
       get { return startCommand ?? (startCommand = new RelayCommand(ExeStartTCommand)); }
    }
