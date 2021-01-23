    public static IList<T> SplitStringUsing<T>(string source, 
        string seperator = ",",
        IFormatProvider provider =null)
        where T:IConvertible
    {
        return source.Split(Convert.ToChar(seperator))
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .Select(x=>Convert.ChangeType(x,typeof(T),provider))
                        .Cast<T>().ToList();
    }
