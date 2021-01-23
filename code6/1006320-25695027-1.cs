    private ICommand startCommand;
    public ICommand StartTCommand
    {
       get { return startCommand ?? (startCommand = new RelayCommand(ExeStartTCommand)); }
    }
    void ExeStartTCommand()
    {
      // Do your stuff here
    }
    void SomeWhereInYourCode(string blah, int lala)
    {
      // do some stuff
      ExeStartTCommand();
      // do some other stuff
    }
