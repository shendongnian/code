    public static bool outval(string value)
    {
        decimal outvalue;
        bool suc = decimal.TryParse(value, out outvalue);
        if (suc)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
