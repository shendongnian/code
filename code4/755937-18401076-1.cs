    private static void Main()
    {
        var client = new GraphClient(new Uri("http://localhost.:7474/db/data"));
        client.Connect();
        
        for (int i = 0; i < 10; i++)
            CreateEmptyNodes(10, client);
    }
    private static void CreateEmptyNodes(int numberToCreate, IGraphClient client)
    {
        var start = DateTime.Now;
        for (int i = 0; i < numberToCreate; i++)
            client.Create(new object());
        
        var timeTaken = DateTime.Now - start;
        Console.WriteLine("For {0} items, I took: {1}ms", numberToCreate, timeTaken.TotalMilliseconds);
    }
