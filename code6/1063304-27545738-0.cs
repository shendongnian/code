    public class T1 {}
    public class T2 {}
    
    public void ProcessRequest (HttpContext context) 
    {
    	object data = null;
    
    	string tablename = context.Request.QueryString["tablename"];
    	if(tablename == "T1")
    	{
    		data = LoadTable1Data();
    	}
    	else if(tablename == "T2")
    	{
    		data = LoadTable2Data();
    	}
    	else
    	{
    		throw new Exception("Unknown tablename: " + tablename);
    	}
    	
    	string jsonData = JsonConvert.SerializeObject(data);
    	context.Response.Write(jsonData);
    }
    
    public List<T1> LoadTable1Data()
    {
    	List<T1> list = new List<T1>();
    	
        ...
    	SqlDataReader reader = cmd.ExecuteReader();
    	while(reader.Read())
    	{
    		list.Add(new T1()); // fill T1 object with row data
    	}
    	
    	return list;
    }
