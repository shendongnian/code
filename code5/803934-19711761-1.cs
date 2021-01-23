    public class Client
    {
    	public int? IndustryId { get; set; }
    	
    	[ForeignKey("IndustryId")]
        public Industry IndustryEntity { get; set; }
    }
