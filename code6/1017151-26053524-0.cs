    /*Thank you Daniel. J.G for the fiddle. I took it as the basis*/
    public class Foo
    {
    	public String Place {get; set;}
    	public String CafeName {get; set;}
    }
    List<Foo> RawFoos = new List<Foo>()
    {
    	new Foo{Place = "x", CafeName = "cafe red"},
    	new Foo{Place = "x", CafeName = "cafe blue"},
    	new Foo{Place = "y", CafeName = "cafe red"},
    	new Foo{Place = "y", CafeName = "cafe blue"},
    	new Foo{Place = "z", CafeName = "cafe red"},
    };
    	
    var pivot = from f in RawFoos
                group f.CafeName by f.Place into g
                //Anonymous object because I'm lazy      
                select new 
  				{ 
   				  Place = g.Key,
   				  CafeRed = g.FirstOrDefault(x => x == "cafe red"),
   				  CafeBlue = g.FirstOrDefault(x => x == "cafe blue")
   				};
   	pivot.Dump(); // only in Linqpad
