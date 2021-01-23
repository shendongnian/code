    public class Person
    {
        public string Name { get; set; }
    	public string SchoolName { get; set; }
        public List<SelectListItem> PossibleSchools 
    	{ 
    		get
    		{
    			return new List<SelectListItem>()
    				{
    					new SelectListItem() { Text = "Rest1", Value = "1" }),
    					new SelectListItem() { Text = "Rest2", Value = "2" }),
    					new SelectListItem() { Text = "Rest3", Value = "3" })
    				};
    		}
    	}
    }
