    Series series = new Series();
    series.type = "foo";
    series.name = "bar";
    
    series.data = new List<List<object>>();
    
    for (int i = 0; i < 5; i++)
    {
    	var data = new List<object>();
    	data.Add(DateTime.Now);
    	data.Add(i);
    	series.data.Add(data);
    }
    
    var json = JsonConvert.SerializeObject(series, Formatting.Indented);
