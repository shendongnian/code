	public abstract class Media
	{
		#region Fields
	
	    private DateTime? _releaseDate;
	
	    #endregion
	
	    #region Constructor
	    public Media() 
	    {
	
	    }
	    #endregion
	
	    #region Properties
	    //Used to convert the Json propertyname
	    [Key]
	    public int MediaId { get; set; }
	
	    [JsonProperty(PropertyName = "id")]
	    public int ApiId { get; set; }
	
	    [JsonProperty(PropertyName = "title")]
	    [MaxLength(200), MinLength(0)]
	    public virtual string Title { get; set; }
	
	
	    [JsonProperty(PropertyName = "overview")]
	    [MaxLength(10000), MinLength(0)]
	    public string Plot { get; set; }
		
		#endregion
	}
	
	public class Movie : Media
	{
		[JsonProperty(PropertyName = "budget")]
		public int Budget { get; set; }
	
		[JsonProperty(PropertyName = "tagline")]
		[MaxLength(1000), MinLength(0)]
		public string Tagline { get; set; }
	
		//[NotMapped]
		//public List<Trailer> Trailers { get; set; }
	}
