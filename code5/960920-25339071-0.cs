    public class DoSomethingToDb(ISessionFactory sessionFactory)
    {
      using (_sessionFactory = _Configuration.BuildSessionFactory())
      using (ISession session = sessionFactory.OpenSession())
      {
    
          //Do Stuff
          session.Flush();
      }
    }
