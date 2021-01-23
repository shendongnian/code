    public interface IEntity
    {
       public int Id { get; set; }    
    }
    // T is IEntity
    public virtual void Delete(T entity)
    {    
       var ent = this.DbContext.Set<T>().Find(entity.Id);
       
       if (ent != null)
       {
           this.DbContext.Set<T>().Remove(entity)
       }
    }
