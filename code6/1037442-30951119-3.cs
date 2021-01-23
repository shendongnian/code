    public void CreateListByNonGenericType<T>(T myObject, string s)
    {
        var lst = new List<T>();
        lst.Add(myObject);
    }
