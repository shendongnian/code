    public ICommand ViewModelCommand { get; set; }
    public ViewModelConstructor()
    {
        ViewModelCommand = new DelegateCommand(ViewModelCommandExecute);
    }
    private void ViewModelCommandExecute()
    {
        // Do something
    }
