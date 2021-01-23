    public static Double? TryGetDouble(this string item, IFormatProvider formatProvider = null)
    {
        if (formatProvider == null) formatProvider = NumberFormatInfo.CurrentInfo;
        Double d = 0d;
        bool success = Double.TryParse(item, NumberStyles.Any, formatProvider, out d);
        if (success)
            return d;
        else
            return null;
    }
