        public static MetadataWorkspace GetMetadataWorkspaceOfCodeFirst<T>() where T : DbContext {
            // require constructor which accepts connection string
            var constructor = typeof (T).GetConstructor(new[] {typeof (string)});
            if (constructor == null)
                throw new Exception("Constructor with one string argument is required.");
            // pass dummy connection string to it. You cannot pass empty one, so use some parameters there
            var ctx = (DbContext) constructor.Invoke(new object[] {"App=EntityFramework"});
            try {                
                var ms = new MemoryStream();
                var writer = new XmlTextWriter(ms, Encoding.UTF8);
                // here is first catch - generate edmx file yourself and save to xml document
                EdmxWriter.WriteEdmx(ctx, writer);
                ms.Seek(0, SeekOrigin.Begin);
                var rawEdmx = XDocument.Load(ms);
                // now we are crude-parsing edmx to get to the elements we need
                var runtime = rawEdmx.Root.Elements().First(c => c.Name.LocalName == "Runtime");                
                var cModel = runtime.Elements().First(c => c.Name.LocalName == "ConceptualModels").Elements().First();
                var sModel = runtime.Elements().First(c => c.Name.LocalName == "StorageModels").Elements().First();
                var mModel = runtime.Elements().First(c => c.Name.LocalName == "Mappings").Elements().First();
                // now we build a list of stuff needed for constructor of MetadataWorkspace
                var cItems = new EdmItemCollection(new[] {XmlReader.Create(new StringReader(cModel.ToString()))});
                var sItems = new StoreItemCollection(new[] {XmlReader.Create(new StringReader(sModel.ToString()))});
                var mItems = new StorageMappingItemCollection(cItems, sItems, new[] {XmlReader.Create(new StringReader(mModel.ToString()))});
                // and done
                return new MetadataWorkspace(() => cItems, () => sItems, () => mItems);
            }
            finally {
                ctx.Dispose();
            }
        }
