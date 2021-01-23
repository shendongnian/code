    public static IList<T> AsList<T>(this T single) {
        return new List<T> { single };
    }
    // you could also include a...
    public static IList<T> AsList<T>(params T[] values) {
        return new List<T>(values);
    }
    // e.g.
    IList<string> myList = single.AsList();
    IList<string> myList = MyUtilClass.AsList(stringA, stringB);
