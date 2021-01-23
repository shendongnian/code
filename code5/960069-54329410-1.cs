    if (assembly.IsDynamic)
    {
            Type assemblyType = assembly.GetType();
    
            Type assemblyBuilderDataType = Assembly.GetAssembly(assemblyType)
                    .GetType("System.Reflection.Emit.AssemblyBuilderData");
    
            object assemblyBuilderData = assemblyType
                    .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .Single(fi => fi.FieldType == assemblyBuilderDataType)
                    .GetValue(assembly);
    
            object assemblyBuilderAccess = assemblyBuilderDataType
                    .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .Single(fi => fi.FieldType == typeof(AssemblyBuilderAccess))
                    .GetValue(assemblyBuilderData);
    
            switch (assemblyBuilderAccess)
            {
                    …
            }
    }
