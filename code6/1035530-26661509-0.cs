    [Queryable(AllowedQueryOptions = AllowedQueryOptions.All)]
    public IQueryable<ObjectDTO> Get()
    {
        return <Repo>.GetAll().Project().To<ObjectDTO>();
    }
