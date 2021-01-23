    public class Organization : Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    
        [Required]
        public string Name { get; set; }
    
        [Required]
        public DateTime Created { get; set; }
    
        [Required]
        public DateTime Updated { get; set; }
    	
    	public override void OnBeforeInsert()
    	{
    		this.Created = DateTime.Now;
    		this.Updated = DateTime.Now;
    	}
    
    	public override void OnBeforeUpdate()
    	{
    		this.Updated = DateTime.Now;
    	}
    }
