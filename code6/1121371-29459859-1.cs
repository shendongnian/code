    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    
    
    					
    public class Program
    {
    	
    	public static void Main()
    	{
    		string json = "{\"trn\":{\"visited_date\":\"2015-04-05\",\"party_code\":\"8978a1bf-c88b-11e4-a815-00ff2dce0943\",\"response\":\"Reason 5\",\"response_type\":\"NoOrder\",\"time_stamp\":\"2015-04-05 18:27:42\",\"trans_id\":\"8e15f00b288a701e60a08f968a42a560\",\"total_amount\":0.0,\"discount\":0.0}}";
    
    		var p = JsonConvert.DeserializeObject<Dictionary<string,trn>>( json );
    		
    		
    		
    		Console.WriteLine(p["trn"].party_code);
    	}
    	public class trn
    	{
    		public string visited_date { get; set; }
    		public string party_code { get; set; }
    		public string response { get; set; }
    		public string response_type { get; set; }
    		public string time_stamp { get; set; }
    		public string trans_id { get; set; }
    		public double total_amount { get; set; }
    		public double discount { get; set; }
    	}
    
    	
    }
