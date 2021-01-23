    // get data from the service
    var serviceData = new List<ServiceObject>
    {
    	new ServiceObject { name = "one", soldTo = "00000123", city = "sydney", state = "nsw", addressLine1 = "king st", addressLine2 = "", zip = "0123", country = "australia" },
    	new ServiceObject { name = "two", soldTo = "00000456", city = "melbourne", state = "vic", addressLine1 = "william st", addressLine2 = "", zip = "0456", country = "australia" },
    	new ServiceObject { name = "three", soldTo = "00000789", city = "adelaide", state = "sa", addressLine1 = "county cres", addressLine2 = "", zip = "0789", country = "australia" }
    };
    
    // convert it to what you want to return
    var jsData = (from row in serviceData
    			  select new JsObject
    			  {
    			      name = row.name,
    				  soldTo = row.soldTo,
    				  address = new JsAddress
    				  {
    				  	  line1 = row.addressLine1,
    					  line2 = row.addressLine2,
    					  postCode = row.zip,
    					  state = row.state,
    					  country = row.country
    				  }
    			  }).ToList();
    
    // turn it into a json string
    var json = JsonSerializer.SerializeToString(jsData);
    
    // this will spit out the result when using Linqpad
    json.Dump("json");
    
    }
    
    class ServiceObject
    {
    	public string name { get; set; }
    	public string soldTo { get; set; }
    	public string city { get; set; }
    	public string state { get; set; }
    	public string addressLine1 { get; set; }
    	public string addressLine2 { get; set; }
    	public string zip { get; set; }
    	public string country { get; set; }
    }
    
    class JsObject
    {
    	public string name { get; set; }
    	public string soldTo { get; set; }
    	public JsAddress address { get; set; }
    }
    
    class JsAddress
    {
    	public string line1 { get; set; }
    	public string line2 { get; set; }
    	public string state { get; set; }
    	public string postCode { get; set; }
    	public string country { get; set; }
    	
