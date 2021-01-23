    var asm = Assembly.Load("RegexLib, Version=1.0.0.1001, Culture=neutral, PublicKeyToken=null");
    var patterns = new List<Regex>();
    foreach (var type in asm.GetExportedTypes())
    {
        if (typeof(Regex).IsAssignableFrom(type))
        {
            patterns.Add((Regex) Activator.CreateInstance(type));
        }
    }
    return patterns;
