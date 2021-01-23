    CultureInfo ci = CultureInfo.CreateSpecificCulture("de-DE");
    var numberformat = ci.NumberFormat;
    double d;
    DateTime date;
    if (DateTime.TryParse(Text, numberformat, DateTimeStyles.None, out date))
    {
        Console.WriteLine(date);
    }
    else if (double.TryParse(Text, NumberStyles.Any, numberformat, out d))
    {
        Console.WriteLine(d); 
    }
