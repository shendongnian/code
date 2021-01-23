    public static IEnumerable<TResult> SelectMy<T, TResult>(this IEnumerable<T> seznam, 
                                                            Func<T, TResult> mapping)
    {
        var ret = new List<TResult>();
    
        foreach (var el in seznam)
        {
            ret.Add(mapping(el));
        }    
        return ret;
    }
