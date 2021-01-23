    public static class MyDatabase
    {
        public static MongoCollection<T> GetCollection<T>(this MongoDatabase db)
        {
            var name = typeof(T).Name;
            return db.GetCollection<T>(name);
        }
    }
