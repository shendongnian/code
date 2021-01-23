    [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
    public IQueryable<ObjectDTO> Get()
    {
        return dbContext.Entities.ProjectTo<ObjectDTO>();
    }
