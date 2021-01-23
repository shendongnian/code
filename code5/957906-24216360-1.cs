    void Main()
    {
    	var dt = new MyData();
    	FillTracking(dt);
    }
    
    public void FillTracking(object data)
    {	
    	data.GetType().GetProperty("LastUpdate").SetValue(data, DateTime.Now);
    }
    
    public class MyData
    {
    	public DateTime LastUpdate { get; set; }
    }
