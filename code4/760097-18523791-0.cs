    public ObjectResult<theSelectedTableNameModel> GetEntityBySQLCommand(string sqlStr, SqlParameter[] filterParams, string OrderByFilter="")
    {
        var commandTextToExecute = OrderByFilter.isNotEmptyOrNull() ? sqlStr : string.Format(“{0} Order By {1}”, sqlStr, OrderByFilter);
        
        return yourObjectContext.ExecuteStoreQuery<theSelectedTableNameModel>(commandTextToExecute, filterParams);
    }
