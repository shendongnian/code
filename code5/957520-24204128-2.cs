    public static TEnum? Merge<TEnum>(this IEnumerable<TEnum> values)
        where TEnum : struct
    {
        if (values == null) return null;
        using (var iter = values.GetEnumerator())
        {
            if (!iter.MoveNext()) return null;
            TEnum merged = iter.Current;
            var or = Operator<TEnum>.Or;
            while(iter.MoveNext())
            {
                merged = or(merged, iter.Current);
            }
            return merged;
        }
    }
