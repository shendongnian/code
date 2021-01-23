    string paramString = "param1=test;param2=test2;param3=test3";    
    IEnumerable<string[]> parameters = paramString.Split(';').Select(y => y.Split('='));
    
    List<SqlParameter> sqlParams = new List<SqlParameter>();
    foreach (string[] parameter in parameters)
    {
    	sqlParams.Add(new SqlParameter(parameter[0], parameter[1]));
    }
    
    Console.WriteLine(sqlParams);
