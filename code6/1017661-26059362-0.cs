    DateTime dt;
    if (DateTime.TryParseExact(strDate, "dd/M/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt))
    {
        Console.WriteLine(dt);
    }
    else
    {
        Console.WriteLine("Can't parse it.");
    }
