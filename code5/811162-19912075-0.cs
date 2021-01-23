    void Main()
    {
    	var doc = XDocument.Load(@"C:\Test\test.xml");
    	
    	var city = doc.Descendants("address_component").FirstOrDefault(e => e.Element("type") != null 
                                && e.Element("type").Value =="locality");
    								
    	if(city != null){						
    	 Console.WriteLine (city.GetElementIfExists("short_name"));
    	} else {
    	 Console.WriteLine ("No short name found");
    	}
    }
    
    public static class Extensions {
     public static string GetElementIfExists(this XElement @this, string element){
       return @this.Element(element) != null ? @this.Element(element).Value : String.Empty;
     }
    }
 
