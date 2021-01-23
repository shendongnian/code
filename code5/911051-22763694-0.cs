    public static string ToDelimitedStr<T>(this T source)
    {
        // Will work for ANY IEnumerable
        if (source is IEnumerable)     // <----------------
        {
            IEnumerable<string> items =
               ((IEnumerable)source).OfType<object>()
                                    .Select(o => o.ToString());
            // convert items to a single string here...
            return string.Join(", ", items);
        }
        return source.ToString();
    }
