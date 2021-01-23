    public static DateTime ToDate(this string input, bool throwExceptionIfFailed = false)
    {
        DateTime result;
        var valid = DateTime.TryParse(input, out result);
        if (!valid)
            if (throwExceptionIfFailed)
                throw new FormatException(string.Format("'{0}' cannot be converted as DateTime", input));
       return result;
    }
