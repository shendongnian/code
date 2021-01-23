    Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyContext, Configuration>());
            using (MyContext temp = new MyContext())
            {
                temp.Database.Initialize(true);
            }
