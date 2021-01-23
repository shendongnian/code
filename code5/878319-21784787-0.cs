    var funcList = new List<Expression<Func<User, object>>>();
     
    funcList.add(u => u.EmailTemplatePlaceholders);
    
    if (useEmailNotices)
        funcList.add(u => u.EmailNotices);
    
    public IQueryable<TEntity> GetAllIncluding(List<Expression<Func<TEntity, object>> includeProperties)
    {
        foreach( ... )
    }
