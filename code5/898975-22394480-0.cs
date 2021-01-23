    public YourDBContext(): base("YourDBConnectionString") 
    {
    	Database.SetInitializer<YourDBContext>(new CreateDatabaseIfNotExists<YourDBContext>());
    	//Database.SetInitializer<YourDBContext>(new DropCreateDatabaseIfModelChanges<YourDBContext>());
    }
