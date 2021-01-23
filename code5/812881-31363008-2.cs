    public partial class Tour
    {
    	public Guid Id { get; set; }
    
    	public Guid CategoryId { get; set; }
    
    	[Required]
    	[StringLength(200)]
    	public string Name { get; set; }
    
    	[StringLength(500)]
    	public string Description { get; set; }
    
    	[StringLength(50)]
    	public string ShortName { get; set; }
    
    	[StringLength(500)]
    	public string TourUrl { get; set; }
    
    	[StringLength(500)]
    	public string ThumbnailUrl { get; set; }
    
    	public bool IsActive { get; set; }
    
    	[Required]
    	[StringLength(720)]
    	public string UpdatedBy { get; set; }
    
    	[ForeignKey("CategoryId")]
    	public virtual TourCategory TourCategory { get; set; }
    }
