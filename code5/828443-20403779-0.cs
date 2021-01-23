    public class DbContext
    {
        public static MongoDatabase GetDatabase()
        {
            var client = new MongoClient("mongodb://localhost");
            var server = client.GetServer();
    
            return server.GetDatabase("test");
        }
    }
