    ValidationCommand = new RelayCommand(ExecuteMyCommand,() => true);
....
    public RelayCommand ValidationCommand
    {
        get;
        private set;
    }
    private void ExecuteMyCommand()
    {
        OnValidate("MyTextValue");
    }
