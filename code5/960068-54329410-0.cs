    Type assemblyBuilderDataType = Assembly.GetAssembly(typeof(AssemblyBuilder)).GetType("System.Reflection.Emit.AssemblyBuilderData");
    object assemblyBuilderData = dynCollAssemType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Single(fi => fi.FieldType == assemblyBuilderDataType).GetValue(dynamicCollectibleAssembly);
    
    object assemblyBuilderAccess = assemblyBuilderDataType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Single(fi => fi.FieldType == typeof(AssemblyBuilderAccess)).GetValue(assemblyBuilderData);  
    switch (assemblyBuilderAccess)
    {
      …      
    }
