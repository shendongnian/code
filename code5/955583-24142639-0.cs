    void Main()
    {
    	var dic = new Dictionary<int, string>()
    	{ 
    		{ 1, "Arne" },
    		{ 2, "Kalle" }
    	};
    	
    	var t = new Test();
    	var props = typeof(Test).GetProperties(BindingFlags.Instance | BindingFlags.Public);
    	foreach (var p in props)
    	{
    		var key = int.Parse(p.Name.Substring(1));
    		string value;
    		if(dic.TryGetValue(key, out value))
    		{
    			p.SetValue(t, value);
    		}
    	}
    }
    
    public class Test
    {
    	public string x1 { get; set; }
    	public string x2 { get; set; }
    }
