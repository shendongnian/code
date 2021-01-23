    private static Type FindImplementation(IEnumerable<Type> implementations, Type expectedTypeParameter)
    {
        Type genericIaType = typeof(IA<>).MakeGenericType(expectedTypeParameter);
        return implementations.FirstOrDefault(x => x.GetInterfaces().Contains(genericIaType));
    }
