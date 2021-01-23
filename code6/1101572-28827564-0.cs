    public class BaseEntity
    {
    	public DateTime ChangedAt {get;set;}
    }
    
    public class ConcreteEntity : BaseEntity
    {
    	public string Name {get;set;}
    }
