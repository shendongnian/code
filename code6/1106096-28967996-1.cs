        foreach (Type type in DLL.GetExportedTypes())
        {
            dynamic c = Activator.CreateInstance(type);
            MethodInfo methodInfo = type.GetMethod("test");
             methodInfo.Invoke(c , null);
        }
    
   
