    public static decimal? ExtractNumberFromStart(string input, NumberFormatInfo nfi = null)
    {
        if (nfi == null) nfi = NumberFormatInfo.CurrentInfo;
        char sep = nfi.NumberDecimalSeparator[0]; // no culture uses multiple characters as separator
        var numberPart = input.TrimStart().TakeWhile(c => Char.IsDigit(c) || c == sep);
        decimal dec;
        if (decimal.TryParse(string.Concat(numberPart), NumberStyles.Number, nfi, out dec))
            return dec;
        else
            return null;
    }
