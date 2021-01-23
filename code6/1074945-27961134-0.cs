    public ICommand Process
    {
        get
        { 
            return new RelayCommand<object>((arg) => 
            {
                Student button = arg as Student;
                ----do something
            }
        });
    }
