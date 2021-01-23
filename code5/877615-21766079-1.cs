    public static IList<T> AsList<T>(this T single) {
        return new List<T> { single };
    }
    // e.g.
    IList<string> myList = single.AsList();
