    public static IEnumerable<dynamic> Test<T>(this T[] source)
    {
        var result = new List<dynamic>();
        foreach(var r in source)
            yield return r.Test();          
    }
