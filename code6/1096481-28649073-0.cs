    public static T Create<T> (object[] parameters) where T : class
    {
        Type[] parameterTypes = (parameters ?? Enumerable.Empty<object> ())
            .Select (parameter => parameter.GetType ()).ToArray ();
        ConstructorInfo ctor = type.GetConstructor (parameterTypes);
        Debug.Assert (ctor != null);
        T instance = ctor.Invoke (parameters) as T;
        Debug.Assert (instance != null);
        return instance;
    }
