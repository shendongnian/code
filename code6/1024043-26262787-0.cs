    /// <summary>
    /// Find all subclasses of a given type via reflection
    /// </summary>
    /// <typeparam name="T">Parent class type</typeparam>
    /// <returns></returns>
    public Type[] GetAllSubclasses<T>() where T : class
    {
        Type[] types = Assembly.GetExecutingAssembly().GetTypes()
                               .Where(t => t.IsSubclassOf(typeof (T))).ToArray();
    
        return types;
    }
    
