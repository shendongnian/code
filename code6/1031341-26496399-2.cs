    public static IList ToAnonymousList(this IEnumerable enumerable)
    {
        var enumerator = enumerable.GetEnumerator();
        if (!enumerator.MoveNext())
            throw new Exception("?? No elements??");
        var value = enumerator.Current;
        var returnList = (IList) typeof (List<>)
            .MakeGenericType(value.GetType())
            .GetConstructor(Type.EmptyTypes)
            .Invoke(null);
        returnList.Add(value);
        while (enumerator.MoveNext())
            returnList.Add(enumerator.Current);
        return returnList;
    }
