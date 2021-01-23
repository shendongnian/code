    public static decimal GetDecimalOrDefault(this string value, decimal defaultDecimal)
    {
        try 
        {
            return Convert.ToDecimal(value);
        }
        catch(exception ex)
        {
            return defaultDecimal;
        }
    }
