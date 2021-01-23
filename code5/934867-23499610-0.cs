    public static MvcHtmlString ForEach<T>(this IEnumerable<T> source, Func<T, Int32, string> action)
    {
        var sb = new StringBuilder();
        Int32 i = 0;
        foreach (T item in source)
        {
            sb.AppendLine(action(item, i));
            i++;
        }
        return new MvcHtmlString(sb.ToString());
    }
