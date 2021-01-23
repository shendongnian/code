    Assembly asm = Assembly.LoadFrom("MyDll.dll");
    Type[] allTypes = asm.GetTypes();
    foreach (Type type in allTypes)
    {
        // Only scan objects that are not abstract and implements the interface
        if (!type.IsAbstract && typeof(IMyInterface).IsAssignableFrom(type));
        {
            // Create a instance of that class...
            var inst = (IMyInterface)Activator.CreateInstance(type);
            
            //do your work here, may be called more than once if more than one class implements IMyInterface
        }
    }
