    public static bool IsIn<T>(this T generic, IEnumerable<T> collection)
    {
        if(collection==null || collection.Count()==0) return false; // just for sure
        return collection.Contains(generic);
    }
