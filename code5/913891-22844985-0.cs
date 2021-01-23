    var projectFiles = System.IO.Directory.GetFiles(
        @"C:\somePath", "*.csproj", SearchOption.AllDirectories);
    
    foreach (var file in projectFiles)
    {
        var xmlFile = XDocument.Load(file);
        var propNode = xmlFile.Root.Elements().First();
        var assemblyName = propNode.Elements().First(x =>x.Name.LocalName == "AssemblyName").Value;
        propNode.Add(new XElement("DocumentationFile", string.Format("somePlace\\{0}.XML", assemblyName)));
        xmlFile.Save(file);
    }
