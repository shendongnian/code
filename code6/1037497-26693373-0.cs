    static List<T> GetInstances<T>()
    {
        return Assembly.GetExecutingAssembly()
            .GetTypes().Where(type =>
                typeof(T).IsAssignableFrom(type) &&
                type.GetConstructor(Type.EmptyTypes) != null)
            .Select(type => (T)Activator.CreateInstance(type))
            .ToList();
    }
