     T defaultObject = ....
   
    public T Add<T>(Func<T> factory) where T : ISerializable
    {
        T item;
        try{
            item = factory();
        }catch(ex){
            Log(ex);
            item = defaultObject;
        }
        base.Add(item);
        return item;
    }
