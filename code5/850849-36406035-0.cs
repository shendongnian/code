    public static MetadataWorkspace GetMetadataWorkspaceFromCodeFirst(Func<string, TContext> createFromConnectionString)
    {
        using (var ctx = createFromConnectionString("App=EntityFramework"))
        using (var ms = new MemoryStream())
        using (var writer = new XmlTextWriter(ms, Encoding.UTF8))
        {
            EdmxWriter.WriteEdmx(ctx, writer);
            ms.Seek(0, SeekOrigin.Begin);
            var xDoc = XDocument.Load(ms);
            var runtime = xDoc.Root.Elements().First(c => c.Name.LocalName == "Runtime");
            var cSpaceLoader = new EdmItemCollection(GetXmlReader(runtime, "ConceptualModels"));
            var sSpaceLoader = new StoreItemCollection(GetXmlReader(runtime, "StorageModels"));
            var mSpaceLoader = new StorageMappingItemCollection(cSpaceLoader, sSpaceLoader,
                GetXmlReader(runtime, "Mappings"));
            return
                _cachedCodeFirst = new MetadataWorkspace(() => cSpaceLoader, () => sSpaceLoader, () => mSpaceLoader);
        }
    }
    private static IEnumerable<XmlReader> GetXmlReader(XContainer runtimeElement, string elementName)
    {
        var model = runtimeElement.Elements().First(c => c.Name.LocalName == elementName).Elements().First();
        yield return XmlReader.Create(new StringReader(model.ToString()));
    }
