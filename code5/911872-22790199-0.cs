    string input = ...;
    input = input.Replace(',', '.');
    double value;
    if (double.TryParse(input, CultureInfo.InvariantCulture))
    {
        // Use value
    }
    else
    {
        // Handle invalid input
    }
