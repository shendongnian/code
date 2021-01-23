    public static InstanceBase GetObject() //you can make the return type even 'T'
    {
        var v = new T();
        v.Method();
        return v;
    }
    //can call like this too:
    ServiceA.GetObject(); //etc
