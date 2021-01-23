    Assembly assembly;
    using (var data = new MemoryStream())
    {
        using (ZipFile zip = ZipFile.Read(LocalCatalogZip))
        {
            zip["assembly.dll"].Extract(data);
        }
        data.Seek(0, SeekOrigin.Begin);
        assembly = Assembly.ReflectionOnlyLoad(data.ToArray());
    }
    var version = assembly.GetName().Version;
