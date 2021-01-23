    public class BunnyManager
    {
        public Bunny<T> GetBunny<T>(string someJson)
        {
           return new Bunny<T>(someJson);
        }
    
        public Bunny GetBunny()
        {
           return new Bunny();
        }
    }
    
    public class Bunny
    {
    
    }
    
    public class Bunny<T> : Bunny
    {
       T parsedJson { get; set; }
    
        public Bunny(string someJson)
        {
            if (!string.IsNullOrEmpty(someJson))
                parsedJson = ConvertJsonStringToObject<T>(someJson);
        }
    }
