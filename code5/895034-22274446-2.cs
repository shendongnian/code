    public void Create(object obj)
    {
        var type = obj.GetType();
        int code = (int)type.GetProperty("Code").GetValue(obj);
        string name = (string)type.GetProperty("ProductName").GetValue(obj);
    }
