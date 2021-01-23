        System.Data.Entity.Database.SetInitializer<EFDbContext>(new DropCreateDatabaseAlways<EFDbContext>());
        // System.Data.Entity.Database.SetInitializer<EFDbContext>(EFDbContext>(null);
        if (!WebMatrix.WebData.WebSecurity.Initialized)
         {
             WebSecurity.InitializeDatabaseConnection("EFDbContext", "UserProfile", "UserId", "UserName", autoCreateTables: true);
         }
