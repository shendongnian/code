    public static bool TryToInt32(object value, ref int result)
    {
        //object has no value
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
        if(Int32.TryParse(value.ToString(), out result))
        {
            return true;
        }
    
        //If that also failed, object cannot be converted or paresed
        return false;
    }
