    public void IterateResourcesInAssembly(string filename)
            {
                var assembly = Assembly.LoadFile(filename);
                string[] resourceNames = assembly.GetManifestResourceNames();
    
                foreach (var resourceName in resourceNames)
                {
                    string baseName = Path.GetFileNameWithoutExtension(resourceName);
                    ResourceManager resourceManager = new ResourceManager(baseName, assembly);
                    
                    var resourceSet = resourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, true);
                    // Exception is thrown!
                }
            }
