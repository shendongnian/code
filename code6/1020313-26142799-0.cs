    public static void AddToList<T, U>(
        this ConcurrentDictionary<T, List<U>> dictionary,
        T key,
        U value
    ) {
    	var list = dictionary.GetOrAdd(key, k => new List<U>());
    	list.Add(value);
    }
