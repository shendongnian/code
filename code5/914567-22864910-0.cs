    String Data = "NAMENAMENAMENAMENAMENAMENAMEAGE119861126";
    var substringInfos = File.ReadLines("Path")
        .SkipWhile(l => string.IsNullOrWhiteSpace(l)).Skip(1) // skip empty lines and the header
        .Select(l => l.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries))
        .Where(split => split.Length == 3)
        .Select(split => new
        {
            Element = split[0],
            Length = int.Parse(split[1]),
            Position = int.Parse(split[2])
        });
    
    foreach (var info in substringInfos)
    {
        string substring = Data.Substring(info.Position, info.Length);
        Console.WriteLine("Element: '{0}' Value: '{1}'", info.Element, substring);
    }
