    private static Assembly loadEmbeddedAssembly(string name)
    {
        if (name.EndsWith("Retargetable=Yes")) {
            return Assembly.Load(new AssemblyName(name));
        }
        // Rest of your code
        //...
    }
