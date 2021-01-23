    public static IList<T> SplitStringUsing<T>(string source, string seperator = ",")
    {
            return source.Split(Convert.ToChar(seperator))
                         .Where(x => !string.IsNullOrWhiteSpace(x))
                         .Select(x=>Convert.ChangeType(x,typeof(T)))
                         .Cast<T>()
                         .ToList();
    }
