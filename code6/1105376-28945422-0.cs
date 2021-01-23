    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    public class Program
    {
    	public class Information
	    {
	 	    public string FirstName{get;set;}
     		public string LastName{get;set;}
    		public string Company{get;set;}
    		public string Address{get;set;}
    	}
    
    	public static void Main()
    	{
    		string myObject =  "\"FirstName\":\"Bart\",\"LastName\":\"Simpson\",\"Company\":\"Fat Tony's\",\"Address\":\"55 Maple Drive\"";
    		var converted = JsonConvert.DeserializeObject<Dictionary<string, object>>("{"+myObject+"}");
	    	var converted2 = JsonConvert.DeserializeObject<Information>("{"+myObject+"}");
		    Console.WriteLine(String.Join("\n", converted.Select(c=> c.Key + ": " + c.Value)));
		    Console.WriteLine(converted2.FirstName);
    	}
    }
