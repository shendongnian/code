    double d;
    if (double.TryParse("12.3", System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out d))
        Console.WriteLine("Value converted {0}", d);
    else
        Console.WriteLine("Unable to parse this number");
