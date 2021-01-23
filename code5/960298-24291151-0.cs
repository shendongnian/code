    public static string GetGeneratedQuery(this SqlCommand dbCommand)
    {
    	var query = dbCommand.CommandTex;
    	foreach (var parameter in dbCommand.Parameters)
    	{
        		query = query.Replace(parameter.ParameterName, parameter.Value.ToString());
    	}
    
    	return query;
    }
