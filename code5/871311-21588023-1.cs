    public static bool IsPercentage(Object value)
    {
        decimal val = 0;
        try
        {
            val = Convert.ToDecimal(value);
        }
        catch
        {
            return false;
        }
        return val >= 0m && val <= 1m;
    }
