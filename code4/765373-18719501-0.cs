    class Event
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public List<string> Participants { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MongoClient client = new MongoClient("mongodb://localhost/test");
            var db = client.GetServer().GetDatabase("test");
            var collection = db.GetCollection("events");
            var event0 = new Event { Name = "Birthday Party", 
                Participants = new List<string> { "Jane Fonda" } };
            collection.Insert(event0);
            collection.Update(Query.EQ("_id", event0.Id),
                Update<Event>.PushAll(p => p.Participants, 
                    new List<string> { "John Doe", "Michael Rogers" }));
        }
    }
