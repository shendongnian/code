            List<Assembly> loadedAssemblies = new List<Assembly>();
            DirectoryInfo di = new DirectoryInfo("path to my assemblies");
            foreach (FileInfo fi in di.GetFiles("*.dll"))
            {
                try
                {
                    loadedAssemblies.Add(Assembly.LoadFrom(fi.FullName));
                }
                catch (Exception ex)
                {
                    // handle problems loading the assemblies here - there are a boatload of possible failures
                }
            }
            foreach (Assembly a in loadedAssemblies)
            {
                // Use reflection to do whatever it is that you wanted to do
            }
