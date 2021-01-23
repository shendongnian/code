    public static IUnityContainer EnableInterception<T>(this IUnityContainer container)
    {
        container.EnableInterception(typeof (T));
        return container;
    }
    public static IUnityContainer EnableInterception(this IUnityContainer container, Type type)
    {
        if (type.IsInterface)
            container.Configure<Interception>().SetInterceptorFor(type, new InterfaceInterceptor());
        else
            container.Configure<Interception>().SetInterceptorFor(type, new VirtualMethodInterceptor());
        return container;
    }
    public static IUnityContainer EnableInterception(this IUnityContainer container, IEnumerable<Type> types)
    {
        foreach (var type in types)
        {
            container.EnableInterception(type);
        }
        return container;
    }
    public static IEnumerable<Type> DerivedFrom<T>(this IEnumerable<Type> types)
    {
        return types.Where(t => typeof (T).IsAssignableFrom(t) && typeof (T) != t);
    }
