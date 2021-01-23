    private Command _myCommand;
    private bool _isChecked;
    public Command MyCommand { get { return _myCommand; } }
    public bool IsChecked
    {
        /* look at the article to see how to use getters and setters */
    }
    private void MyCommand_C()
    {
        IsChecked = !IsChecked;
        _dataModel._groupBoxEnabled = IsChecked;
    }
