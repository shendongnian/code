    using System;
    using System.Linq;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Conventions;
    using MongoDB.Driver;
    
    namespace playground
    {
        class Simple
        {
            public ObjectId Id { get; set; }
            public String Name { get; set; }
            public int Counter { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                MongoClient client = new MongoClient("mongodb://localhost/test");
                var db = client.GetServer().GetDatabase("test");
                var collection = db.GetCollection<Simple>("Simple");
                var pack = new ConventionPack();
                pack.Add(new CamelCaseElementNameConvention());
                ConventionRegistry.Register("camel case", pack, t => true);
                collection.Insert(new Simple { Counter = 1234, Name = "John" });
                var all = collection.FindAll().ToList();
                Console.WriteLine("Name: " + all[0].Name);
            }
        }
    }
