    // Get the assembly containing the implementations. I'm assuming both interface and implementation are in the same assembly
    Assembly assembly = typeof(IClass).Assembly;
    // Get type. note that know we made use of the aseembly to locate the Type.
    Type t = assembly.GetType(className);
        IClass calculator = (IClass)Activator.CreateInstance(t);
