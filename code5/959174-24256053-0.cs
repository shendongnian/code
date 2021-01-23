    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    
    public class Program
    {
    	public static void Main()
    	{
            WebClient client = new WebClient();
    
            using (Stream stream = client.OpenRead("http://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&explaintext=1&titles=stack%20overflow"))
            using (StreamReader reader = new StreamReader(stream))
            {
                JsonSerializer ser = new JsonSerializer();
                Result result = ser.Deserialize<Result>(new JsonTextReader(reader));
    			
    			foreach(Page page in result.query.pages.Values)
    				Console.WriteLine(page.extract);
            }
    	}
    }
    
    public class Result
    {
    	public Query query { get; set; }
    }
    
    public class Query
    {
    	public Dictionary<string, Page> pages { get; set; }
    }
    
    public class Page
    {	
    	public string extract { get; set; }
    }
