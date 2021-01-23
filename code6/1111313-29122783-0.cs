    private static IDictionary<Type,BasicClass> instances = new Dictionary<Type,BasicClass>();
    ...
    public static T GetInstance<T>() where T : BasicClass {
        BasicClass res;
        if (!instances.TryGetValue(typeof(T), out res)) {
            res = (BasicClass)Activator.CreateInstance(typeof(T));
            instances.Add(typeof(T), res);
        }
        return (T)res;
    }
    ...
    var o = MyClass2.GetInstance<MyClass2>();
