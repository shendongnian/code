    public class RootObject
    {
    	public List<Person> Men { get; set; }
    	public List<Person> Women { get; set; }
    }
    
    public class Person
    {
    	[JsonProperty("name")]
    	public string Name { get; set; }
    	
    	[JsonProperty("phone")]
    	public string PhoneNumber { get; set; }
        public Sex Sex { get; set }
    }
    public enum Sex
    {
    	Man,
    	Women
    }
