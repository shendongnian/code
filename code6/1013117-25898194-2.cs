    public abstract class TestBase
    {
        public string Host { get; set; }
    	
    	[JsonProperty("last_time")]
        public DateTime LastTime { get; set; }
        
    	public string Name { get; set; }
        public string Result { get; set; }
        
    	[JsonProperty("start_time")]
    	public DateTime StartTime { get; set; }
        public string Version { get; set; }
    }
    
    public class TestSuite : TestBase
    {
        public string Serial { get; set; }
        public List<TestBase> Subtests { get; set; }
    }
    
    public class Subtest : TestBase
    {
        public JObject Data { get; set; }
    
        public string Description { get; set; }
    }
