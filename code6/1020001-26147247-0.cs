    public static Task<IEnumerable<T>> ExecuteAsync<T>(this DataServiceQuery<T> query)
    {
        return Task.Factory.FromAsync(query.BeginExecute, query.EndExecute, null);
    }
    …
    public static Task<IEnumerable<ASHPersonify.OrderDetailInfo>> ExecuteCustomersQueryAsync()
    {
        var query = 
            (DataServiceQuery<ASHPersonify.OrderDetailInfo>)
            (SvcClient.Ctxt.OrderDetailInfos
                .Where(a =>a.ShipMasterCustomerId == "pppp" 
                    && a.ShipSubCustomerId == 0
                    && a.LineStatusCode == "A"));
    
        try
        {
            return await query.ExecuteAsync();
        }
        catch (DataServiceQueryException ex)
        {
            throw new ApplicationException(
                "An error occurred during query execution.", ex);
        }
    }
