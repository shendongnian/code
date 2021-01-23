    public MobileWalletContext() : base("Ver3ConnectionString")
    {          
        Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MobileWalletContext>()); 
    }
    
