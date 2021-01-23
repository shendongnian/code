    private RelayCommand _testCommand;
    public RelayCommand TestCommand
    {
        get
        {
            return _testCommand ?? (_testCommand = new RelayCommand(TestWord, CanTestWord));
        }
        set
        {
            if (_testCommand == value) return;
            _testCommand = value;
        }
    }
    public bool CanTestWord()
    {
        return some boolean test that defines if the command can run now;
    }
    private void TestWord()
    {
         Incident.Start = DateTime.Now;
    }
