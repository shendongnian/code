        //if OpenSession() throws it's fine , not transaction at all
        using (ISession session = databaseFacade.OpenSession())
        {
            using (ITransaction tx = session.BeginTransaction())
            {
              try
              {
                  // do some work
                  ...
                  tx.Commit();
              }
              catch (Exception e)
              {
                //tx is not null at this point
                tx.Rollback();
                throw;
              }
            }
        }
