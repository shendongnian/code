    Assembly asm = Assembly.LoadFrom("MyDll.dll");
    Type[] allTypes = asm.GetTypes();
    foreach (Type type in allTypes)
    {
        // Only scan objects that are not abstract
        if (!type.IsAbstract)
        {
            // If a class implements the IMyInterface interface,
            Type iMyInterface = type.GetInterface("IMyInterface");
            if (iMyInterface != null)
            {
                // Create a instance of that class...
                var inst = asm.CreateInstance(type.FullName) as IMyInterface;
    
                if (inst != null)
                {
                     //do your work here
                }
            }
        }
    }
