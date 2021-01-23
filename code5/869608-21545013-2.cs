        string source = ...
        string references = ...
        // Compile
        CodeDomProvider provider = new CSharpCodeProvider();
        CompilerParameters cp = new CompilerParameters(references);
        cp.GenerateExecutable = false;
        cp.GenerateInMemory = true;
        CompilerResults res = provider.CompileAssemblyFromSource(cp, source);
        // Extract object
        Type t = res.CompiledAssembly.GetType(className);
        MethodInfo method = t.GetMethod(methodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);          // Get method
        // Run
        object instance =  Activator.CreateInstance(t, this);
        object ret = method.Invoke(instance, null); 
