    public class NameId
    {
    	public string  Name {get;set;}
        public string  Id {get;set;}
    	public ThisType Type { get; set; }
    }
    
    public enum ThisType
    {
       username,
       profile
    }
