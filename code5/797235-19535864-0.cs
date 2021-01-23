    public class UserModel
    {
    	public string Name { get; set; }
    	// Some other properties..
    	
    	public int CountryId { get; set; }
    	
    	public IEnumerable<SelectListItem> Countries { get; set; }
    }
