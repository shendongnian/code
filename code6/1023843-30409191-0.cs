    public async Task<Object> GetMyList(ODataQueryOptions<MyObject> options = null)
    {
        // Get your list from SharePoint
        List<MyObject> myObjects = GetMyObjectListFromSharePoint();
        // This will apply the OData query parameters 
        // to your IQueryable object but won't execute the query
        IQueryable query = options.ApplyTo(myObjects.AsQuerable());
        
        // This will execute the above query 
        // and return the new list of MyObject
        List<Object> result = await query.ToListAsync();
        
        // Do post result actions
        return result;
    }
