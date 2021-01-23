    var rootDir = @"e:\temp";
    var folders = XDocument.Load(filename)
                    .Descendants("folder")
                    .Select(x => Path.Combine(GetParents(x).Reverse().ToArray()))
                    .OrderBy(x => x);
    foreach(var dir in folders)
    {
        Directory.CreateDirectory(Path.Combine(rootDir,dir));
    }
---
    IEnumerable<string> GetParents(XElement x)
    {
        while (x != null)
        {
            if (x.Name.LocalName == "folder") yield return x.Attribute("name").Value;
            x = x.Parent;
        }
    }
