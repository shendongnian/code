    public static DateTime ConvertTimeStampToDateTime(double value)
    {
        DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0); //Unix Epoch on January 1st, 1970
    
        return origin.AddMilliseconds(value);
    }
