    var assembly = Assembly.GetExecutingAssembly();
    string configFileContents;
    using(StreamReader reader = new StreamReader(assembly.GetManifestResourceStream("MySolutionNamespace.ContainingFolder.SiteConfiguration.json"), Encoding.Unicode))
    {
        configFileContents = reader.ReadToEnd();
    }
    Console.WriteLine(configFileContents);
    Console.ReadKey();
