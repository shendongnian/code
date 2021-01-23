    public class EntityA : TDomainEntity
    {
    	public EntityB BValue { get; set; }
    	public DateTime InsertDT { get; set; }
    }
    
    public class EntityB : TDomainEntity
    {
    	public DateTime InsertDT { get; set; }
    }
