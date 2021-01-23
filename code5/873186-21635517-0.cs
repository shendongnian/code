    [Queryable]
    public Task<IQueryable<ContentType>> Get()
    {
        // mock
        var userId = 111;
    
        var unitOfWork = new Repository.UnitOfWork(_db);
    
        return unitOfWork.Repository<ContentType>().Query()
            .Filter(u => u.UserId == userId)
            .GetAsync();
    }
