    public class Person : BaseEntity
    {
    	public string FirtName { get; set; }
    	public string LastName { get; set; }
        
    	public virtual PersonAddress Address { get; set; }
    	...
    }
    
    public class PersonAddress : BaseEntity
    {
    	DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
    	[Key, ForeignKey("Person")]
    	public override int ID { get; set; }
    
    	[ForeignKey("ID")]
    	public virtual Person Person { get; set; }
    	...
    }
