    public YourViewModel()
    {
        this.SetAllDatesToNowCommand =
            new RelayCommand(this.ExecuteSetAllDatesToNowCommand);
    }
    ...
    public void ExecuteSetAllDatesToNowCommand()
    {
        this.selectedIncident.Start = DateTime.Now;
        // etc.
    }
