    public static TV Put<TK, TV, TC>(this IDictionary<TK, TC> dictionary, TK key, TV value)
        where TC : class, ICollection<TV>, new()
    {
        ...
    }
