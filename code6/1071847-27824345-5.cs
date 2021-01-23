     public YourDbContext()
        : base("DefaultConnection")
    {
        this.Configuration.LazyLoadingEnabled = true;
    }
