    public static IEnumerable<T> SelectExt<R, T>(this IEnumerable<R> list, params Func<R, T>[] GetValueList)
    {
        var result = new List<T>(list.Count() * GetValueList.Length);
        foreach (var item in list)
        {
            foreach (var getValue in GetValueList)
            {
                var value = getValue(item);
                result.Add(value);
            }
        }
    
        return result;
    }
