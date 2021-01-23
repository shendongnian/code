    // for IEnumerable
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
        // for IQueryable
        public static IList ToAnonymousList(this IQueryable source)
        {
            if (source == null) throw new ArgumentNullException("source");
            var returnList = (IList) typeof (List<>)
                .MakeGenericType(source.ElementType)
                .GetConstructor(Type.EmptyTypes)
                .Invoke(null);
            foreach (var elem in source)
                returnList.Add(elem);
            return returnList;
        }
