    public void InsertOrUpdate(T entity, Expression<Func<T, bool>> Findpredicate)
    {   
        T _dbRecord = this.FindBy(Findpredicate).FirstOrDefault();
        if (_dbRecord != null)
        {
            context.CreateObjectSet<T>().ApplyCurrentValues(entity);
        }
        else
        {
            context.CreateObjectSet<T>().AddObject(entity);
        }
        context.SaveChanges();
    }
