        public static void ReplaceResource(string path, string resourceName, byte[] resource)
        {
            var definition =
                AssemblyDefinition.ReadAssembly(path);
            for (var i = 0; i < definition.MainModule.Resources.Count; i++)
                if (definition.MainModule.Resources[i].Name == resourceName)
                {
                    definition.MainModule.Resources.RemoveAt(i);
                    break;
                }
            var er = new EmbeddedResource(resourceName, ManifestResourceAttributes.Public, resource);
            definition.MainModule.Resources.Add(er);
            definition.Write(path);
        }
        public static void AddResource(string path, string resourceName, byte[] resource)
        {
            var definition =
                AssemblyDefinition.ReadAssembly(path);
            var er = new EmbeddedResource(resourceName, ManifestResourceAttributes.Public, resource);
            definition.MainModule.Resources.Add(er);
            definition.Write(path);
        }
        public static MemoryStream GetResource(string path, string resourceName)
        {
            var definition =
                AssemblyDefinition.ReadAssembly(path);
            foreach (var resource in definition.MainModule.Resources)
                if (resource.Name == resourceName)
                {
                    var embeddedResource =(EmbeddedResource) resource;
                    var stream = embeddedResource.GetResourceStream();
                    var bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, bytes.Length);
                    var memStream = new MemoryStream();
                    memStream.Write(bytes,0,bytes.Length);
                    memStream.Position = 0;
                    return memStream;
                }
            return null;
        }
