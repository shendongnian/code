 	[Table( Name = "Activities" )]
	public class Activity
    {
	    [PrimaryKey, Identity]
	    [Column(Name = "ActivityId"), NotNull]
	    public string Id { get; set; }
	    [Column( Name = "CustomerId" )] 
	    public int? CustomerId; 
	}
