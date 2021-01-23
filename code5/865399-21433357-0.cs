    public static string ToValueSeparatedString(this IEnumerable<string> source, string separator)
    {
        if (source == null || source.Count() == 0)
        {
            return string.Empty;
        }
    
        return source
            .DefaultIfEmpty()
            .Aggregate((workingLine, next) => string.Concat(workingLine, separator, next));
    }
