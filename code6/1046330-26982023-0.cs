    string[] samples = { "10,000.00", "10.000,00" };
    CultureInfo deDE = new CultureInfo("de-DE");
    foreach (string sample in samples)
    {
        double value;
        bool parsable = double.TryParse(sample, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out value);
        if(!parsable)
            parsable = double.TryParse(sample, NumberStyles.Any, deDE, out value);
        Console.WriteLine(value); // output 10000 with both
    }
