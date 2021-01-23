    public interface IHealthDataContext
    {
       DbConnection Connection { get; }
       IDbSet<MyClass> MyClasses{ get; }
    
       int SaveChanges();
    }
