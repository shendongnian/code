    static double Parse(string str, IFormatProvider provider = null)
    {
        if (str == string.Empty)
        {
            return 0;
        }
        if (provider == null)
        {
            provider = CultureInfo.CurrentCulture;
        }
        NumberFormatInfo nfi = NumberFormatInfo.GetInstance(provider);
        // [ws][sign][integral-digits[,]]integral-digits[.[fractional-digits]][E[sign]exponential-digits][ws]
        string ws = @"\s*";
        string sign = @"(" + Regex.Escape(nfi.PositiveSign) + "|" + Regex.Escape(nfi.NegativeSign) + ")?";
        string integralDigits1 = "([0-9](" + Regex.Escape(nfi.NumberGroupSeparator) + ")*)*";
        string integralDigits2 = "[0-9]+";
        string fractionalDigits = "(" + Regex.Escape(nfi.NumberDecimalSeparator) + "[0-9]*)?";
        string exponentialDigits = "([Ee]" + sign + "[0-9]+)?";
        var rx = new Regex(ws + sign + integralDigits1 + integralDigits2 + fractionalDigits + exponentialDigits);
        string match = rx.Match(str).ToString();
            
        if (match == string.Empty)
        {
            return 0;
        }
        return double.Parse(match, provider);
    }
