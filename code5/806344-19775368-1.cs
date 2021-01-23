    public static Type GetInterface(this Type type, Type targetType)
    {
        return type.GetInterfaces().SingleOrDefault(t => t.IsGenericType
                              && t.GetGenericTypeDefinition() == targetType);
    }
    public class Surface : ISurface<int> { /* ... */ }
    typeof(Surface).GetInterface(typeof(ISurface<>)); //returns typeof(ISurface<int>)
    typeof(NotASurface).GetInterface(typeof(ISurface<>)); //returns null
