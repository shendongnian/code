    [HttpPost]
    [EnableQuery]
    public PageResult<SomeObject> SomeFunction(ODataQueryOptions<SomeObject> options, ODataActionParameters parameters)
    {
        // Get the paging settings from ODataActionParameters since they are not shown on the ODataQueryOptions. Maybe there will be some fix for this in the future.
        int pageSize = (int)parameters["pageSize"];
        int take = (int)parameters["take"];
        int skip = (int)parameters["skip"];
        int page = (int)parameters["page"];
            
        // Apply page size settings
        ODataQuerySettings settings = new ODataQuerySettings();
        // Create a temp result set to hold the results from the stored procedure
        var tempResults = db.SomeStoredProc().ToList(); // ToList is required to get the "real" total count before paging
        // Apply the query options. For now this is only needed to get the correct count since the options does not seem to contain the TOP / SKIP when using OData parameters.
        IQueryable results = options.ApplyTo(tempResults.AsQueryable(), settings);
        // This was needed for custom paging. EXAMPLE: http://www.asp.net/web-api/overview/odata-support-in-aspnet-web-api/supporting-odata-query-options
        return new PageResult<SomeObject>(tempResults.Skip(skip).Take(take),
                                Request.ODataProperties().NextLink,
                                Request.ODataProperties().TotalCount);
    }
