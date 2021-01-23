    public interface IRepository
    {
     void Add(MyType object);
    }
    
    public class SqlRepository : IRepository
    {
     public void Add(MyType object)
     {
      // saves to DB
     }
    } 
    
    public class InMemoryRepository : IRepository
    {
     List<MyType> store = new List<MyType>();
     
     public void Add(MyType object)
     {
      // saves to list store.
      // may also, additionally store to DB.
      IRepository dbRep = DependencyInjection.GiveMeDatabaseRepository<IRepository>();
       
      // null check so that if tomorrow, there is no SQL repository, this code doesn't break.
      if (dbRep != null )
      {
       dbRep.Add(object);
      }
     }
    
     // this is another explicit option
     public void AddToDatabase(MyType object)
     {
       IRepository dbRep = DependencyInjection.GiveMeDatabaseRepository<IRepository>();
       dbRep.Add(object);
     }
    }
 
