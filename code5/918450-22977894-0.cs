    public void MyMethod<T>(List<T> objectList) where T:class, new()
    {
        objectList.Add(new T());
        ...
    }
