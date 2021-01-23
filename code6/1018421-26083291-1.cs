    public virtual void Delete(T entity)
    {    
       var ent = this.DbContext.Set<T>().Find(entity.Id);
       
       if (ent != null)
       {
           this.DbContext.Set<T>().Remove(entity)
       }
    }
