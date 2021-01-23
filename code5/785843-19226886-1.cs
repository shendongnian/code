    [HttpGet]        
    public PageResult<PersistedUser> GetAllUsers(
        ODataQueryOptions<PersistedUser> options)
    {
        TableServiceContext serviceContext = tableClient.GetDataServiceContext();
        serviceContext.IgnoreResourceNotFoundException = true;
        CloudTableQuery<PersistedUser> users = serviceContext
            .CreateQuery<PersistedUser>(TableNames.User)
            .AsTableServiceQuery();    
        IQueryable<PersistedUser> results = options.ApplyTo(users);
        int skip = options.Skip == null ? 0 : options.Skip.Value;
        int take = options.Top == null ? 25 : options.Top.Value;
        return new PageResult<PersistedUser>(
            results.Skip(skip).Take(take).ToList(), 
            Request.GetNextPageLink(),
            null);
    }
