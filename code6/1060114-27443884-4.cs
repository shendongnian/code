    static void Main(string[] args)
    {
        var section = ConfigurationManager.GetSection("resources") as ResourceGroup;
        foreach (ResourceItem item in section.Items)
        {
            Console.WriteLine(item.Title);
        }
        Console.ReadKey();
    }
