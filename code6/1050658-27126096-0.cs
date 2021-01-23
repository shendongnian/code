    MyType1[] result = JsonConvert.Deserialize<MyType1[]>(jsonArray);
    MyType2[] result = JsonConvert.Deserialize<MyType2[]>(jsonArray);
    public class MyType1 
    {
    	public string key { get; set; }
    	public string value { get; set; }
    }
    
    public class MyType12
    {
    	public string key { get; set; }
    	public double value { get; set; }
    }
