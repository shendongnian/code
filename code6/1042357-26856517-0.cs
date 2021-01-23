    foreach (Dictionary<string, object> item in (IEnumerable)answer)
    {
        Console.WriteLine("id: " + item["id"]);
        if (item.ContainsKey("children"))
        {
            Console.WriteLine("children:");
            foreach (Dictionary<string, object> child in (IEnumerable)item["children"])
            {
                Console.WriteLine("   id: " + child["id"]);
            }
        }
    }
