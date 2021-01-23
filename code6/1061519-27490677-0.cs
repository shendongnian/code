    protected void Application_Start()
    {
      //Other calls...
      Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
    }
