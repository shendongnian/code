    public class CityResponse
        {
            public string status { get; set; }
            public string message { get; set; }
            public string result { 
    		    get{ return null; }
        		set{
        			    // if 1st character is "[" then it's an array of City, otherwise a City object 
                        //depending on the above parse this string (which is like "{prop1: qqq, prop2: www}" 
                        // or like "[{prop1: qqq, prop2: www}, {prop1: eee, prop2: eee}]")
                        // by the existing serializer or other one 
    	    		    // into City or array of cities
    	    		    // if City, then convert in to array of cities
    	    	        // and save result into realResult
    	    	}
        	}
            public List<City> realResult { get; set; }
