    public static bool IsAssemblyDebugBuild(Assembly assembly)
    {
        return assembly.GetCustomAttributes(false)
            .OfType<DebuggableAttribute>()
            .Any(i => i.IsJITTrackingEnabled);
    }
