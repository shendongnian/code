    public class Team
    {
    	[Key]
    	public int TeamId { get; set; }
    	public string Name { get; set; }
    	public string Code { get; set; }
    	public int? GroupId { get; set; }
    	public virtual Group Group { get; set; }
    }
