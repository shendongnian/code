    public T GetAut<T>(string pw) where T : class, new(), IAutObj
    {
        var obj = new T();
        obj.pw = pw;
        return obj;
    }
