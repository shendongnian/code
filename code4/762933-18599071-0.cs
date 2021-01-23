    public void RegisterType(Type implType, Type ifaceType)
    {
        ...
    }
    public void RegisterType<TImpl, TIface>() where TImpl : TIface
    {
        this.RegisterType(typeof(TImpl), typeof(TIface));
    }
