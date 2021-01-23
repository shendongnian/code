    Database.SetInitializer<UsersContext>(null);
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("DBConnectionString", "Users", "UserId", "UserName", autoCreateTables: true);
            }
