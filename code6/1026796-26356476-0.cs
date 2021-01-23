    public abstract class Document // or interface, whichever is appropriate for you
    {
    	//some non-validted common properties
    }
    
    public class ValidatedDocument : Document
    {
    	[Required]
    	public string Name {get;set;}
    }
    
    public class AnotherValidatedDocument : Document
    {
    	[Required]
    	public string Name {get;set;}
    
    	//I would suggest finding a descriptive name for this instead of Name2, 
    	//Name2 doesn't make it clear what it's for
    	public string Name2 {get;set;}
    }
    
    public class NonValidatedDocument : Document
    {
    	public string Name {get;set;}
    }
    //Etc...
