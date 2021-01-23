    string input = "1234 1/2";
    decimal? inputAsDec = null;
    if (input.Contains('/') && input.Contains(' '))
    {
        var wholeAndFraction = input.Split(' ');
        var fraction = wholeAndFraction[1].Split('/');
        decimal? numerator = null;
        decimal? denominator = null;
        bool parsed = true;
        if (!decimal.TryParse(fraction[0], out numerator)
        {
            parsed = false;
        }
        if (!decimal.TryParse(fraction[1], out denominator)
        {
            parsed = false;
        }
        if (parsed && decimal.TryParse(wholeAndFraction[0], out inputAsDec)
        {
            inputAsDec += numerator / denominator;
            // do stuff with the value
        }
    }
    else
    {
        if (decimal.TryParse(input, out inputAsDec)
        {   
            // use the bool value to do stuff
        }
    }
