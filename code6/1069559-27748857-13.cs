    public LargeDecimal() : this("0") { }
    public LargeDecimal(string value)
    {
        if (value == null) throw new ArgumentNullException("value");
        string number = value.Replace(" ", ""); // remove spaces
        number = number.TrimStart('0'); // remove leading zeroes
        IsNegative = (number.IndexOf('-') == 0); // check for negative
        number = number.Replace("-", ""); // remove dashes
        // add a zero if there were no numbers before a decimal point
        if (number.IndexOf('.') == 0) number = "0" + number; 
        // Initialize lists
        wholeDigits = new List<int>();
        decimalDigits = new List<int>();
        // Get whole and decimal parts of the number
        var numberParts = number.Split(new[] {'.'}, 
            StringSplitOptions.RemoveEmptyEntries);
        IsWhole = numberParts.Length == 1;
        // Add whole digits to the list
        wholeDigits.AddRange(numberParts[0].Select(n => int.Parse(n.ToString())));
        // Add decimal digits to the list (if there are any)
        if (numberParts.Length > 1 && 
            numberParts[1].Sum(n => int.Parse(n.ToString())) > 0)
        {
            numberParts[1] = numberParts[1].TrimEnd('0');
            decimalDigits.AddRange(numberParts[1].Select(n => int.Parse(n.ToString())));
        }
        NormalizeLists();
    }
    public LargeDecimal(LargeDecimal initializeFrom)
    {
        wholeDigits = initializeFrom.wholeDigits
            .GetRange(0, initializeFrom.wholeDigits.Count);
        decimalDigits = initializeFrom.decimalDigits
            .GetRange(0, initializeFrom.decimalDigits.Count);
        IsWhole = initializeFrom.IsWhole;
        IsNegative = initializeFrom.IsNegative;
        NormalizeLists();
    }
