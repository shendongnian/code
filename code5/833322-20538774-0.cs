    /// <summary>
    /// Execute a mapping from the source object to a new destination object
    /// with explicit <see cref="System.Type"/> objects
    /// </summary>
    static object Map(object source, Type sourceType, Type destinationType)
    /// <summary>
    /// Create a map between the <paramref name="sourceType"/> and
    /// <paramref name="destinationType"/> types and execute the map.
    /// Use this method when the source and destination types are
    /// not known until runtime.
    /// </summary>
    static object DynamicMap(object source, Type sourceType, Type destinationType)
