    public static string GetGeneratedQuery(this SqlCommand dbCommand)
    {
    	var query = dbCommand.CommandText;
    	foreach (var parameter in dbCommand.Parameters)
    	{
        		query = query.Replace(parameter.ParameterName, parameter.Value.ToString());
    	}
    
    	return query;
    }
