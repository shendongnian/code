    string year = Console.ReadLine();
    DateTime validYear;
    if (!DateTime.TryParseExact("yyyy", year, CultureInfo.InvariantCulture, DateTimeStyles.None, out validYear))
    {
        Console.WriteLine("Invalid Year");
    }
