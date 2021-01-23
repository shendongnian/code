    var providersTable = new DataTable();
    providersTable.Columns.Add("value", typeof(Int32));
    foreach (var value in filterModel.Providers)
    {
    	providersTable.Rows.Add(value);
    }
    var providers = providersTable.AsTableValuedParameter("[dbo].[tblv_int_value]");
    
    var filters =
    	new
    	{
    		campaignId = filterModel.CampaignId,
    		search = filterModel.Search,
    		providers = providers,
    		pageSize = requestContext.PageSize,
    		skip = requestContext.Skip
    	};
    
    using (var query = currentConnection.QueryMultiple(StoredProcedureTest, filters, nhTransaction, commandType: CommandType.StoredProcedure))
    {
    	var countRows = query.Read<int>().FirstOrDefault();
    	var temp = query.Read<CategoryModel>().ToList();
    	return new Result<IEnumerable<CategoryModel>>(temp, countRows);
    }
