    string[] empDetails = { "1,abc,2,11k", "2,de,3,11k", "3,abc,2,18k", "4,abdc,2,12k" };
    string[] empToRemove = { "1", "3" };
    
    var remove = new HashSet<string>(empToRemove);
    foreach (var item in empDetails)
    {
        string id = item.Substring(0, item.IndexOf(','));
        if (!remove.Contains(id))
            Console.WriteLine(item);
    }
