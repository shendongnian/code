    public static GetStringOrNull(this IDataRecord dr, int i)
    {
        return dr.IsDBNull(i) 
               ? null 
               : dr.GetString(i);
    }
