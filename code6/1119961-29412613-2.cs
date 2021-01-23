    interface IEntity {
    	public int Id { get; }
    	public string Name { get; }
    }
    
    [Table("buildings")]
    public class Building : IEntity
    {
        [Column("id")]
        [Key]
        public int Id {get;set;}
    
        [Column("description")]
        public string Description {get;set;}
    	
    	[NotMapped]
    	public string Name { get { return this.Description; } }
    }
    
    [Table("cars")]
    public class Car : IEntity
    {
        [Column("id")]
        [Key]
        public int Id {get;set;}
    
        [Column("title")]
        public string Title {get;set;}
    	
    	[NotMapped]
    	public string Name { get { return this.Title; } }
    }
