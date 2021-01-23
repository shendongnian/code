    public static void TestMe<T>(Action<List<T>> action)
    {
        List<T> collection = new List<T>();
        collection.Add((T)(object)"123"); //I do not know, how you fill the collection
        action(collection);
    }
