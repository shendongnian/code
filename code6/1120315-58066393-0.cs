    public class Player
    {
    	public string name {get; set;}
    	public int age {get; set;}
    	public double salary {get; set;}
    	public string gender {get; set;}
    	public DateTime contractSignDate {get; set;} 
        public IList<TeamPlayer> Team { get; set; }
    }
    
    public class Team
    {
    	public string teamName {get; set;}
    	public string sportPlayed {get; set;}
    	public List<TeamPlayer> players {get; set;}
    }
    
