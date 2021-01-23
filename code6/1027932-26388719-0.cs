    public class PhoneType
    {
    	public string typeid { get; set; }
    	public string Value { get; set; }
    }
    
    public IEnumerable<PhoneType> PhonetypeOptions =
    new List<PhoneType>
    {
    	new PhoneType {typeid = "Mobile", Value = "Mobile"},
    	new PhoneType {typeid = "Home", Value = "Home"},
    	new PhoneType {typeid = "Office", Value = "Office"}
    };
