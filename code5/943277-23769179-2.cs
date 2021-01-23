    string year = Console.ReadLine();
    DateTime validYear;
    if (!DateTime.TryParseExact(year, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out validYear))
    {
        Console.WriteLine("Invalid Year");
    }
