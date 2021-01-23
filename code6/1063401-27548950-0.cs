    string input = value.ToString().Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);
    double number;
    bool result = Double.TryParse(input , out number);
    if (result)
    {
        return number;         
    }
    else
    {
        return input;
    }
