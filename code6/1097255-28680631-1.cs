    public static TEnumerable MyExtensionMethod<T, TEnumerable>(this TEnumerable enumerable)
        where TEnumerable : IEnumerable<T>
    {
        ...
    }
