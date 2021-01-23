    void Main()
    {
    	 Console.WriteLine(GetSqlTypes());
    }
    
    Dictionary<string,Type> GetSqlTypes()
    {
       var types=new Dictionary<string,Type>();
       var a = Assembly.Load("System.Data");
         foreach (var sqlType in a.GetTypes().Where(t=>t.Namespace=="System.Data.SqlTypes" 
                        && t.Name.StartsWith("Sql")
    					 && !t.Name.Contains("Exception")
    					 && !t.Name.Contains("Schema")
    					 && !t.Name.Contains("Stream")))
             {
                types.Add(sqlType.Name,sqlType);
             }
    		 return types;
    }
