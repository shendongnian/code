    public IPagedList<MyObject> GetAll<T>(Expression<Func<MyObject, T>>? orderBy, 
        int pageNumber = 1, int pageSize = 10)
    {
        if (orderBy == null) 
        {
            orderBy = x => x.Id;
        }
        return dataContext.MyObjects
          .OrderBy(orderBy)
          .ToPagedList<MyObject>(pageNumber, pageSize);
    }
