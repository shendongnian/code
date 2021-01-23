    var parameters = parameter.ToOracleParameters();
    var inParameterList = string.Join(", ", 
    	parameters.Where(x => x.Direction == ParameterDirection.Input)
    		.Select(x => ":" + x.ParameterName));
    var outParameter = parameters.Single(x => x.Direction == ParameterDirection.Output);
    var sql = string.Format("BEGIN :{0} := MY_ORACLE_FUNCTION({1}); end;", 
    	outParameter.ParameterName, inParameterList);
    
    DbContext.Database.SqlQuery<object>(sql, parameters.Cast<object>().ToArray()).SingleOrDefault();
