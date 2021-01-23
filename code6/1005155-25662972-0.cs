    public interface IMyInterface
    {
        void callclass();
    }
    public <T> getConstructorClass()
    {
        T instance;
        Type type = Type.GetType("test1");
        // instance will be null if the object cannot be cast to type T.
        instance = Activator.CreateInstance(type) as T;
        return T;
    }
    IMyInterface objcls = getConstructorClass<IMyInterface>();
    if(null != objcls)
    {
        objcls.callclass();
    }
