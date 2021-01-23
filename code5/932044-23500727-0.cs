    private static bool DoesAssemblyMatchLoad(Assembly assemblyToTest)
    {
        try
        {
            var loadedAssembly = Assembly.Load(assemblyToTest.FullName);
            return assemblyToTest.CodeBase == loadedAssembly.CodeBase;
        }
        catch (FileNotFoundException)
        {
            return false;
        }
    }
