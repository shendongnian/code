    var guestCounts = new Dictionary<int, List<string>>
    {
        { 1, new List<string>() },
        { 2, new List<string>() },
        { 3, new List<string>() }
    }
    foreach (string s in File.ReadAllLines(filePath))
    {
        int choice;
        if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out choice) &&
            guestCounts.ContainsKey(choice))
        {
            guestCounts[choice].Add(s);
            Console.WriteLine("{0} has been added to Guest{1}", s, choice);
        }
        else
        {
            Console.WriteLine("Default has been used.");
        }
    }
