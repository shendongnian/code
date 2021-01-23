    dynamic dynParams = new ExpandoObject();
	dynParams.v1 = new Dapper.DbString()
	{
		Value = "yay",
		IsAnsi = true,
		Length = 50
	};
	
	var parameters = new Dapper.DynamicParameters();
	
	((ExpandoObject)dynParams).ToList().ForEach(kvp => parameters.Add(kvp.Key, kvp.Value));
