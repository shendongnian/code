    public static bool IsPercentage(Object value)
    {
        int val = 0;
        try
        {
            val = Convert.ToInt32(value);
        }
        catch
        {
            return false;
        }
        return val >= 0 && val <= 1;
    }
