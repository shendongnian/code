    public static bool TryToInt32(object value, out int result)
    {
        result = 0;
        if (value == null)
        {
            return false;
        }
    
        //Try to convert directly
        try
        {
            result = Convert.ToInt32(value);
            return true;
        }
        catch
        {
            //Could not convert, moving on
        }
    
        //Try to parse string-representation
        if (Int32.TryParse(value.ToString(), out result))
        {
            return true;
        }
    
        //If parsing also failed, object cannot be converted or paresed
        return false;
    }
