    public void Next()
    {
        this.StartDate = StartDate.AddMonths(3);
        this.EndDate = EndDate.AddMonths(3);
        this.OnPropertyChanged("StartDate");
        this.OnPropertyChanged("EndDate");
    }
    
    public void Previous()
    {
        this.StartDate = StartDate.AddMonths(-3);
        this.EndDate = EndDate.AddMonths(-3);
        this.OnPropertyChanged("StartDate");
        this.OnPropertyChanged("EndDate");
    }
