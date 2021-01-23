    public static String Join(this IEnumerable enumerable)
    {
        var stringEnumerable = enumerable as IEnumerable<string>;
        if (stringEnumerable != null)
        {
            return String.Join(",", stringEnumerable);
        }
        var enumerable2 = enumerable as IEnumerable<IEnumerable>;
        if (enumerable2 != null)
        {
            return String.Join(",", enumerable2.Select(e => e.Join()));
        }
        return String.Join(",", enumerable.Select(e => e.ToString()));
    }
