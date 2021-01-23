    public MyEventsDataContext()
        : base("MyEventsDatabase")
    {
        this.Configuration.LazyLoadingEnabled = true;
    }
