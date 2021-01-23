    public class Response<T> where T : new()
    {
        [JsonProperty("hasErrors")]
    	public bool HasErrors { get; set; }
    
    	[JsonProperty("includes")]
    	public Includes<T> Includes { get; set; }
    }
    
    public class Includes<T> where T : new()
    {
    	[JsonProperty("products")]
    	public Dictionary<string, T> Products { get; set; }
    }
    
    public class Product
    {
    	[JsonProperty("hej")]
    	public string Hej { get; set; }
    }
