    void Main()
    {
    	var dt = new MyData();
    	FillTracking(dt);
    }
    
    public void FillTracking(TrackableObject obj)
    {
    	obj.LastUpate = DateTime.Now;
    }
    
    public class TrackableObject
    {
        public DateTime LastUpate { get; set; }
    }
    
    public class MyData : TrackableObject
    {
    
    }
