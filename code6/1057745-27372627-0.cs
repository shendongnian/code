    public static List<T> ConvertArrayListToList<T>(CollectionClass paramcollection)
    {
        return paramcollection.Cast<T>().ToList(); 
    
    }
