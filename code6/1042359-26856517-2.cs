    List<Item> answer = json_serializer.Deserialize<List<Item>>(result);
    foreach (Item item in answer)
    {
        Console.WriteLine("id: " + item.Id);
        if (item.Children != null)
        {
            Console.WriteLine("children:");
            foreach (Item child in item.Children)
            {
                Console.WriteLine("   id: " + child.Id);
            }
        }
    }
