    // Get your assembly.
    Assembly asm = Assembly.LoadFile(Assembly.GetExecutingAssembly().Location);
    // Get your point of entry.
    MethodInfo entryPoint = asm.EntryPoint;
    // Invoke point of entry with arguments.
    entryPoint.Invoke(null, new object[] { new string[] { "arg1", "arg2", "etc" } } );
