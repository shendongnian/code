    public static TElem GetOrNew<TList, TElem>(this TList collection, int key) 
        where TList : IList<TElem>, TElem:new()
    {
        ...
    }
    public static TElem Set<TList, TElem>(this TList collection, int key, TElem value) 
        where TList: IList<TElem>
    {
        ...
    }
    public static TVal GetOrNew<TDict, TKey, TVal>(this TDict collection, TKey key) 
        where TDict : IDictionary<TKey, TVal>, TVal : new()
    {
        ...
    }
    public static TVal Set<TDict, TKey, TVal>(this TDict collection, TKey key, TVal value) 
        where TDict : IDictionary<TKey, TVal>
    {
        ...
    }
    public static TVal GetOrNew<TColl, TKey, TVal>(this TDict collection, TKey key) 
        where TColl : IIndexable<TKey, TVal>, TVal: new()
    {
        ...
    }
    public static TVal Set<TColl, TKey, TVal>(this TDict collection, TKey key, TVal value) 
        where TColl : IIndexable<TKey, TVal>
    {
        ...
    }
