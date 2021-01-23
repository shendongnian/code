    XElement sitemap = XElement.Parse(result, LoadOptions.None);
    foreach (var bodyElement in sitemap.Elements("body"))
    {
        foreach (var fieldElement in bodyElement.Elements())
        {
           Console.WriteLine(fieldElement.Name);
           Console.WriteLine(fieldElement.Value);
        }
    }
