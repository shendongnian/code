    public static String Join<T>(this IEnumerable<T> enumerable)
    {
        var enumerable2 = enumerable as IEnumerable<IEnumerable>;
        if (enumerable2 != null)
        {
            return String.Join(",", enumerable2.Select(e => e.Join()));
        }
        return String.Join(",", enumerable.Select(e => e.ToString()));
    }
