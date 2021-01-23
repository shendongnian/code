    public interface IMyDataContext
    {
       DbConnection Connection { get; }
       IDbSet<MyClass> MyClasses{ get; }
    
       int SaveChanges();
    }
