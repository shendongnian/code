    public static IEnumerable<dynamic> Test<T>(this IEnumerable<T> source)
    {
        if (source is List<T>) {
            // here 
        }
        var result = new List<dynamic>();
        foreach(var r in source)
            yield return r.Test();          
    }
