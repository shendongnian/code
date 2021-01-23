    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
    namespace JsonExp
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    
    			string json = File.ReadAllText(@"D:\json\jsonResponse.txt");
    			JObject jsonResults = JObject.Parse(json);
    
    			// get JSON result objects into a list
    			IList<JToken> results = jsonResults ["credits"]["cast"].Children().ToList();
    
    			// serialize JSON results into .NET objects
    			IList<Actor> searchResults = new List<Actor>();
    			foreach (JToken result in results)
    			{
    				Actor searchResult = JsonConvert.DeserializeObject<Actor>(result.ToString());
    			  searchResults.Add(searchResult);
    			}
    
    			foreach (var actor in searchResults)
    			{
    				Console.WriteLine("{1}[{0}] as {2} Path: {3}", actor.Name, actor.Id, actor.Character, actor.ProfilePath);
    			}
    
    			Console.ReadKey();
    		}
    	}
    
    	#region Json classes
    	public class Credits
    	{
    		[JsonProperty(PropertyName = "cast")]
    		public List<Actor> List { get; set; }
    	}
    
    	public class Actor
    	{
    		[JsonProperty(PropertyName = "id")]
    		public int Id { get; set; }
    
    		[JsonProperty(PropertyName = "name")]
    		public string Name { get; set; }
    
    		[JsonProperty(PropertyName = "character")]
    		public string Character { get; set; }
    
    		[JsonProperty(PropertyName = "order")]
    		public string Order { get; set; }
    
    		[JsonProperty(PropertyName = "cast_id")]
    		public string CastId { get; set; }
    
    		[JsonProperty(PropertyName = "profile_path")]
    		public string ProfilePath { get; set; }
    	}
    	#endregion
    }
