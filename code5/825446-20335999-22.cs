    public class SearchListing1
    {
    	public int property_id { get; set; }
    	public string property_name { get; set; }
    	public int office_property_id { get; set; }
    	public string description { get; set; }
    }
    
    public class GroupOfficeProperty
    {
    	public int property_id { get; set; }
    	public int office_property_id { get; set; } 
    }
