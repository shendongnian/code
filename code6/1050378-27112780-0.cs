    public class JSONClass
    {
    	public string dummy { get; set; }
    	public Dictionary<string, Link> links;
    
    	public class Link
    	{
    		public string Href { get; set; }
    		public string Method { get; set; }
    	}
    }
