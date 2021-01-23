    public class C
    {
        public int Id { get; set; }
        public string S { get; set; }
    }
    public static class Program
    {
        public static void Main(string[] args)
        {
            ConventionRegistry.Register(
                "Ignore null values",
                new ConventionPack
                {
                    new IgnoreIfNullConvention(true)
                },
                t => true);
            var client = new MongoClient("mongodb://localhost");
            var server = client.GetServer();
            var database = server.GetDatabase("test");
            var collection = database.GetCollection<C>("test");
            collection.Drop();
            collection.Insert(new C { Id = 1, S = null });
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
    }
