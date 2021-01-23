    public class TestController : ApiController
    {
    	public YourOutput Get()
    	{
    		var openTimes = new Dictionary<string, string>
    		{
    			{"1", "0:09"},
    			{"2", "2:09"},
    			{"3", "1:09"},
    		};
    
    		return new YourOutput() { openTimes = openTimes };
    	}
    }
    
    public class YourOutput
    {
    	public Dictionary<string, string> openTimes { get; set; }
    }
