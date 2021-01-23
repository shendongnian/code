    public List<string> Members 
    { 
        get { return _Members; }
        set { _Members = value; OnPropertyChanged(); } 
    }
    public MainVM()
    {
        // Simulate Asychronous access, such as to a db.
    
        Task.Run(() =>
                    {
                        Thread.Sleep(2000);
                        Members = new List<string>() {"Alpha", "Beta", "Gamma", "Omega"};
                    });
    }
