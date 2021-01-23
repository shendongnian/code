    var guestCounts = new Dictionary<int, List<string>>
    {
        { 1, new List<string>() },
        { 2, new List<string>() },
        { 3, new List<string>() }
    }
    // Collect inputs
    foreach (string food in File.ReadAllLines(filePath))
    {
        int guest;
        if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out guest) &&
            guestCounts.ContainsKey(guest))
        {
            guestCounts[guest].Add(food);
            Console.WriteLine("{0} has been added to Guest{1}", food, guest);
        }
        else
        {
            Console.WriteLine("Default has been used.");
        }
    }
    // Output results
    foreach (int guest in guestCounts.Keys)
    {
        foreach (string food in guestCounts[guest])
        {
            Console.WriteLine("Guest {0} had {1}", guest, food);
        }
    }
