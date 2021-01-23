    {
            TestContext devDB  = new TestContext("Arial", 10.0f);
             try
             {
                 devDB = new TestContext(constr);  
                 Container                 
                    .RegisterInstance<TestContext>(devDB)
                    .RegisterInstance<IRepository<User>>(new Repository<User>(devDB))
             }
             finally
             {
                if (devDB != null)
                   ((IDisposable)devDB).Dispose();
             }
      }
