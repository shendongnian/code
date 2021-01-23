    public static string MyJoin<T>(this IEnumerable<T> items)
    {
        if (typeof(T) == typeof(string)
        {
            return items.Cast<string>().MyStringJoin();
        }
        var innerIEnumerableType = typeof(T).GetInterfaces().FirstOrDefault(x => x.IsGeneric() 
            && x.GetGenericType() == typeof(IEnumerable<>);
        if (innerIEnumerableType != null)
        {
            // create generic method to 
            var method = typeof(ThisType).GetMethod("MyJoin", /* some flags */)
                .MakeGenericMethod(innerIEnumerableType.GetGenericArguments().First())
            // recursive call to generic method
            return items.Select(x => (string)method.Invoke(null, x)).MyStringJoin();
        }
        throw new InvalidOperationException("Type is not a (nested) enumarable of strings")
    }
    public static string MyStringJoin(this IEnumerable<string> strings)
    {
        return string.Join(Environment.NewLine, strings);
    }
