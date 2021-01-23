    public Dictionary<Type, List<PropertyInfo>> DetectParameterProperties()
    {
        Dictionary<Type, List<PropertyInfo>> lookup = new Dictionary<Type, List<PropertyInfo>>();
        IEnumerable<Type> operations = Assembly
            .GetAssembly(typeof(IOperation))
            .GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && typeof(IOperation).IsAssignableFrom(t));
        foreach (Type operation in operations)
        {
            lookup[operation] = new List<PropertyInfo>();
            IEnumerable<PropertyInfo> parameters = operation.GetProperties().Where(p => p.CustomAttributes.Any(a => a.AttributeType == typeof(ParameterAttribute)));
            foreach (PropertyInfo parameter in parameters)
                lookup[operation].Add(parameter);
        }
        return lookup;
    }
