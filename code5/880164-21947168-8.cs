    public class Account
    {
    	public int Id { get; set; }
    	public string AccountName { get; set; }
    
    	[JsonIgnore]
    	public virtual Account DefaultAssignTo { get; set; }
    	public int? DefaultAssignToId { get; set; }
    
    	[JsonIgnore]
    	public virtual ICollection<Role> Roles { get; set; }
    
    	[JsonIgnore]
    	public virtual Other Other { get; set; }
    	public int? OtherId { get; set; }
    
    	[JsonConverter(typeof(StringConverter))]
    	public string OtherName
    	{
    		get
    		{
                    return "Name = " + this.AccountName;
    		}
    	}
