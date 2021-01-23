    public class MyDatabase
    {
        private MongoDatabase _db;
    
        public MyDatabase(MongoDatabase db)
        {
            _db = db;
        }
    
        public MongoCollection<object> Objects
        {
            get
            {
                return _db.GetCollection<object>();
            }
        }
    }
