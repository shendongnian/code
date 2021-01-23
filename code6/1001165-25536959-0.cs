    void Main()
    {
        List<RowValues> v = new List<RowValues>();
        var key = "Key"; //GetFromConfig();
	
        var v1 = new RowValues();
        v1.Add("Key", "1");
        v1.Add("3", "5");
	
        var v2 = new RowValues();
        v2.Add("Key", "3");
        v2.Add("2", "2");
	
        var v3 = new RowValues();
        v3.Add("Key", "2");
        v3.Add("2", "2");
	
        v.Add(v1);
        v.Add(v2);
        v.Add(v3);
	
        v.OrderBy(r => r[key]).Dump();
    }
    class RowValues : Dictionary<string, string>
    {
	
    }
