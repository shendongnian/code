    var rootDir = @"e:\temp";
    var folders = XDocument.Load(filename)
                    .Descendants("file")
                    .Select(x => Path.Combine(GetParents(x).Reverse().ToArray()))
                    .Distinct()
                    .OrderBy(x => x)
                    .ToList();
    foreach(var dir in folders)
    {
        Directory.CreateDirectory(Path.Combine(rootDir,dir));
    }
---
    IEnumerable<string> GetParents(XElement x)
    {
        x = x.Parent;
        while (x != null)
        {
            if (x.Name.LocalName == "folder") yield return x.Attribute("name").Value;
            x = x.Parent;
        }
    }
