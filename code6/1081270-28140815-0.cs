    var doc = XDocument.Load("...");
    var assemblies = doc.Descendants("LeagueSharpAssembly")
        .OrderBy(r => r.Element("DisplayName").Value);
    foreach (var a in assemblies)
    {
        Console.WriteLine("Assembly {0}", a.DisplayName);
    }
