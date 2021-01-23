    public class City
    {
    	public int CityId { get; set; }
    	public string CItyName { get; set; }
    }
    public class State
    {
    	public int StateId { get; set; }
    	public string StateName { get; set; }
    }
    public class CurrentPresident
    {
    	public int PresidentId { get; set; }
    	public string PresidentName { get; set; }
    }
    public class Country
    {
    	public Country()
    	{
    		this.President = new CurrentPresident();
    		this.States = new List<State>();
    		this.Cities = new List<City>();
    	}
    
    	public int CountryId { get; set; }
    	public CurrentPresident President { get; set; }
    	public IList<State> States { get; set; }
    	public IList<City> Cities { get; set; }
    }
