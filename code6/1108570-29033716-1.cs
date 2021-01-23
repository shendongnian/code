    static double Parse(string str, IFormatProvider provider)
    {
        if (str == string.Empty)
        {
            return 0;
        }
        NumberFormatInfo nfi = NumberFormatInfo.GetInstance(provider);
        string integralPart = @"^\s*((" + Regex.Escape(nfi.PositiveSign) + "|" + Regex.Escape(nfi.NegativeSign) + ")?[0-9]" + "((" + Regex.Escape(nfi.NumberGroupSeparator) + ")*[0-9]?)*)?";
        string fractionalPart = "(" + Regex.Escape(nfi.NumberDecimalSeparator) + "[0-9]*)?";
        string exponentialPart = "([Ee](" + Regex.Escape(nfi.PositiveSign) + "|" + Regex.Escape(nfi.NegativeSign) + ")?[0-9]+)?";
        var rx = new Regex(integralPart + fractionalPart + exponentialPart);
        string match = rx.Match(str).ToString();
            
        if (match == string.Empty)
        {
            return 0;
        }
        return double.Parse(match, provider);
    }
