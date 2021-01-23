    AppDomain.CurrentDomain.AssemblyResolve += (s, e) =>
        {
            Assembly asm = null;
    
            if (e.Name == "otherAssembly.dll")
            {
                byte[] assemblyBytes = // code to retrieve assembly from resources.
                asm = Assembly.Load(assemblyBytes);
            }
    
            return asm;
        };
