     class Program
    {
        static void Main(string[] args)
        {
            var client = new GraphClient(new Uri("http://localhost:7474/db/data"),"neo4j","password");
            client.Connect();
            Console.WriteLine("Done");
        }
    }
