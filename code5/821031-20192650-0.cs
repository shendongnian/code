    private static Type[] GetDatafileTypes()
    {
        Type delegateType = typeof(Delegate);
        Assembly assembly = Assembly.GetAssembly( typeof ( Importer ) );
        return
            assembly.GetTypes()
                .Where( t => t.IsSerializable && t.IsPublic && !delegateType.IsAssignableFrom(t))
                .ToArray();
    }
