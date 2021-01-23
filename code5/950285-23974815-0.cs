    public abstract class ModelBase
    {
       // code
    }
    
    public abstract class ModelBaseIdentity<T>: ModelBase
    {
       public virtual T Id { get; set; }
    }
    
    public class Table: ModelBaseIdentity<int>
    {
       public string Name { get; set; }
    }
    
    
    public class Repository<TEntity> 
             : IRepository<TEntity> where TEntity 
             : ModelBase
