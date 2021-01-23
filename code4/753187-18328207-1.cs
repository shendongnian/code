    private static IEnumerable<Assembly> Assemblies
    {
        get
        {
            if (_assemblies == null)
            {
                // Cache the list of relevant assemblies, since we need it for both Pre and Post
                _assemblies = new List<Assembly>();
                foreach (var assemblyFile in GetAssemblyFiles())
                {
                    try
                    {
                        // Ignore assemblies we can't load. They could be native, etc...
                        _assemblies.Add(Assembly.LoadFrom(assemblyFile));
                    }
                    catch
                    {
                    }
                }
            }
            return _assemblies;
        }
    }
 
