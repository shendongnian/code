    AssemblyInfo ai = AssemblyInfo.Parse("assembliesPath","yourassembly.dll");
    IEnumerable<AssemblyInfo> sorted = ai.OrderedDependencies();
    foreach (AssemblyInfo item in sorted)
    {
        Console.WriteLine(item.Item.ManifestModule.ToString());
    }
