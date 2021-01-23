    string str = "911125";
    DateTime dt;
    if (DateTime.TryParseExact(str
                                , "yyMMdd"
                                , CultureInfo.InvariantCulture
                                , DateTimeStyles.None
                                , out dt))
    {
        Console.WriteLine(dt.ToString("dd MMMM yyyy"));
    }
    else
    {
        Console.WriteLine("Invalid date string");
    }
