    string[] samples = { "10,000.00", "10.000,00" };
    CultureInfo deDE = new CultureInfo("de-DE");  // to support your "European format"
    NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands;
    foreach (string sample in samples)
    {
        double value;
        bool parsable = double.TryParse(sample, style, NumberFormatInfo.InvariantInfo, out value);
        if(!parsable)
            parsable = double.TryParse(sample, style, deDE, out value);
        Console.WriteLine(value); // output 10000 with both
    }
