    public RelayCommand<string> AddFieldCommand { get; private set; }
    
    public ViewModelConstructor()
    {
       AddFieldCommand = new RelayCommand<string>(AddField);
    }
    
    private void AddField(string text)
    {
       // Do something
    }
