    using System.IO;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    namespace JsonExp
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    
    			string json = File.ReadAllText(@"D:\json\jsonResponse.txt");
    			Movie test = JsonConvert.DeserializeObject<Movie>(json);
    		}
    	}
    
    	class Movie
    	{
    		[JsonProperty(PropertyName = "credits")]
    		public Credits ActorsInMedia { get; set; }
    
    
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
    	}
    }
