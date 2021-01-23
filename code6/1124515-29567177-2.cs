    string input = "1234 1/2";
    decimal? inputAsDec = null;
    decimal? fractionAsDec = null;
    var wholeAndFraction = input.Split(' ');
    if (wholeAndFraction.Count == 2 && input.Contains('/'))
    {
        var fraction = wholeAndFraction[1].Split('/');
        decimal? numerator = null;
        decimal? denominator = null;
        if (decimal.TryParse(fraction[0], out numerator) && decimal.TryParse(fraction[1], out denominator))
        {
            fractionAsDec = numerator / denominator;
        }
    }
    if (decimal.TryParse(wholeAndFraction[0], out inputAsDec))
    {
        if (fractionAsDec != null)
        {
            inputAsDec += fractionAsDec;
        }
    }
