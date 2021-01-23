    public class User
    {
        public string Player { get; set; }
        public string Money{ get; set; }
    }
    public class Database
    {
        public List<User> User { get; set; }
        public static Database LoadFromFile(string path)
        {
            var fs = File.Open(path);
            var serializer = new XmlSerializer(typeof(DataBase));
            var db = (Database)serializer.Deserialize(fs);
            return db;
        }
    }
