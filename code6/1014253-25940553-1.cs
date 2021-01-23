        [Test]
        public void InitializeDatabaseTestWithMatchingModel()
        {
            //set initializer for data context to test it, and run it
            Database.SetInitializer<POSDatabaseContext>(new CustomDropCreateDatabaseWithMatchingModelTest());
            database.Database.Initialize(true);
            POSDatabaseContext newContext = new POSDatabaseContext(connectionString);
            
            //use the metata table to check if it was run correctly
            //if metadata exist, which it should
            if(newContext.Metadata.Any(s => s.ID == "META"))
            {
                Metadata actual = newContext.Metadata.Single(s => s.ID == "META");
                Assert.IsTrue(actual.IsInitialized);
            }
            else
                throw new Exception("The Database was not seeded correctly");         
        }
