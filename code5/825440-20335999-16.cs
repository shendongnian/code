    public class OfficeProperty
    {
    	public int office_property_id { get; set; }
    	public int property_id { get; set; }
    	public int office_id { get; set; }
    	public string description { get; set; }
    }
    public class Office
    {
    	public int office_id { get; set; }
    	public String office_name { get; set; }
    }
    
    public class Property
    {
    	public int property_id { get; set; }
    	public string property_name { get; set; }
    }
