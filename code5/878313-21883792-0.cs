    public static State GetState(string stateTypeName)
    {
        var list = FindAllDerivedStates();
        dynamic returnedValue = new NullState();
        foreach(var state in list)
        {
            if(state.Name == stateTypeName) returnedValue = (State)Activator.CreateInstance(state);
        }
        return returnedValue
    }
    
    private static List<Type> FindAllDerivedStates()
    {
        var derivedType = typeof(State);
        var assembly = Assembly.GetAssembly(typeof(State));
        return assembly.GetTypes().Where(t => t != derivedType && derivedType.IsAssignableFrom(t)).ToList();
    }
