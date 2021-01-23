    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    public class RootObject
    {
        public string url_short { get; set; }
        public string url_long { get; set; }
        public int type { get; set; }
    }
    
    public class Program
    {
        static public void Main()
        {
		   using (StreamReader r = new StreamReader(Server.MapPath("~/test.json")))
		   {
			   string json = r.ReadToEnd();
			   List<RootObject> ro = JsonConvert.DeserializeObject<List<RootObject>>(json);
		   }
        Console.WriteLine(ro[0].url_short);                 
        }  
    }
