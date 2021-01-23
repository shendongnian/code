    string input = "12.5PerRs";
    decimal? dec = ExtractNumberFromStart(input);
    if (dec.HasValue)
    {
        string number = dec.ToString();                // 12.5
        string alpha = input.Substring(number.Length); // PerRs
    }
