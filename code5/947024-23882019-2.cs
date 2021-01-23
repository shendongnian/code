    public static bool IsAssemblyDebugBuild(Assembly assembly)
    {
        foreach (var attribute in assembly.GetCustomAttributes(false))
        {
            var debuggableAttribute = attribute as DebuggableAttribute;
            if(debuggableAttribute != null)
            {
                return debuggableAttribute.IsJITTrackingEnabled;
            }
        }
        return false;
    }
