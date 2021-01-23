        public class NewsFeed
        {
          public string Id;
          public string CreatedTime;
          public Tag From;
        }
        
        public class Tag
        {
          [JsonConstructor]
          public NewsFeed(string category, string name, string id)
          {
             Category = category;
             Name = name;
             Id = id
          }
          public string Category;
          public string Name;
          public string Id;
        }
