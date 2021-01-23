     private static void InitContainer()
     {
           using(var devDB = new TestContext(constr))_
           {  
                     Container                 
                        .RegisterInstance<TestContext>(devDB)
                        .RegisterInstance<IRepository<User>>(new Repository<User>(devDB))
           }
      }
