    public void CreateListByNonGenericType(object myObject)
    {
        Type objType = myObject.GetType();
        Type listType = typeof(List<>).MakeGenericType(objType);
        IList lst = Activator.CreateInstance(listType);
    }
