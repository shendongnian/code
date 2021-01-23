    public string Url
    {
        ...
    
        set
        {
            ...
    
            try
            {
                this.Execute(DriverCommand.Get, parameters);
            }
            ...
        }
    }
