    [HttpGet]        
    public PageResult<PersistedUser> GetAllUsers(
        ODataQueryOptions<PersistedUser> options)
    {
        TableServiceContext serviceContext = tableClient.GetDataServiceContext();
        serviceContext.IgnoreResourceNotFoundException = true;
        var users = serviceContext
            .CreateQuery<PersistedUser>(TableNames.User)
            .AsTableServiceQuery();    
        var results = options
            .ApplyTo(users.AsQueryable()) as IQueryable<PersistedUser>;
        int skip = options.Skip == null ? 0 : options.Skip.Value;
        int take = options.Top == null ? 25 : options.Top.Value;
        return new PageResult<PersistedUser>(
            results.Skip(skip).Take(take), 
            Request.GetNextPageLink(),
            null);
    }
