    public static T SpawnObject<T>()
    {
        return (T)SpawnObject(typeof(T));
    }
    private static object SpawnObject(Type objType)
    {
        var parameters = objType.GetConstructors().Single().GetParameters();
        List<object> paramObjects;
        if (!parameters.Any()) return Activator.CreateInstance(objType);
        paramObjects = new List<object>();
        foreach (var item in parameters)
        {
            //var arg = Activator.CreateInstance(item.ParameterType);
            var paramType = item.ParameterType;
            var arg = SpawnObject(paramType);
            paramObjects.Add(arg);
        }
        return Activator.CreateInstance(objType, paramObjects.ToArray());
    }
