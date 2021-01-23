    List<Item> items = new List<Item>();
    foreach (String line in File.ReadAllLines("filepath"))
    {
        Item item = new Item
        {
             ItemNumber = Convert.ToInt32(line.Split('|')[0]),
             Total = Convert.ToInt32(line.Split('|')[1])
        };
    }
