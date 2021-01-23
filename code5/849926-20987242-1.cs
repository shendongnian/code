    private static bool Test<T>(T obj1, T obj2)
    {
        if (typeof(T).IsGenericType)
        {
            var obj1List = obj1 as System.Collections.IList;
            var obj2List = obj2 as System.Collections.IList;
    
            if (obj1List != null && obj2List != null && obj1List.Count == obj2List.Count)
                return true;
        }
        return false;
    }
