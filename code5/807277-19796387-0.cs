    public DataTable ExecuteStoreQuery(string commandText, params Object[] parameters)
    {
       DataTable retVal;
       
       var entities = context.ExecuteStoreQuery<MyEntity>(commandText, parameters)
                              .Take(1); // use `Take` instead of `First` to keep it as a collection
       retVal = entities.AsEnumerable().CopyToDataTable();
       return retVal;
    }
