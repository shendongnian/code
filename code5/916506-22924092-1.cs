    public IPagedList<MyObject> GetAll<T>(Expression<Func<MyObject, T>>? orderBy, 
        int pageNumber = 1, int pageSize = 10)
    {
        IQueryable<MyObject> objects = dataContext.MyObjects;
        objects = (orderBy != null) ? objects.OrderBy(orderBy) 
                                    : objects.OrderBy(x => x.Id);
        return objects.ToPagedList<MyObject>(pageNumber, pageSize);
    }
