    public class Movie
    {
    	public int Id {get;set;}
    	public string Title {get;set;}
    	public string Director {get;set;}
    	public DateTime ReleaseDate {get;set;}
    	public List<Actor> Cast {get;set;}
    }
    public enum Gender {
    	Male, Female
    }
    public class Actor {
    	public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthdate { get; set; }
    }
