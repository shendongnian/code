    private RelayCommand _testCommand;
    public RelayCommand TestCommand
    {
        get
        {
            return _testCommand ?? (_testCommand = new RelayCommand(TestUpdate, CanRunTest));
        }
        set
        {
            if (_testCommand == value) return;
            _testCommand = value;
        }
    }
    public bool CanRunTest()
    {
        return some boolean test that defines if the command can run now;
    }
    private void TestUpdate()
    {
         Incident.Start = DateTime.Now;
    }
