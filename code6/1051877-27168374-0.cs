    var searcherPreVista = new ManagementObjectSearcher(string.Format(@"\\{0}\root\SecurityCenter", Environment.MachineName), "SELECT * FROM AntivirusProduct");
    var searcherPostVista = new ManagementObjectSearcher(string.Format(@"\\{0}\root\SecurityCenter2", Environment.MachineName), "SELECT * FROM AntivirusProduct");
    var preVistaResult = searcherPreVista.Get().OfType<ManagementObject>();
    var postVistaResult = searcherPostVista.Get().OfType<ManagementObject>();
    
    var instances = preVistaResult.Concat(postVistaResult);
    
    var installedAntivirusses = instances
        .Select(i => i.Properties.OfType<PropertyData>())
        .Where(pd => pd.Any(p => p.Name == "displayName") && pd.Any(p => p.Name == "pathToSignedProductExe"))
        .Select(pd => new
        {
            Name = pd.Single(p => p.Name == "displayName").Value,
            Path = pd.Single(p => p.Name == "pathToSignedProductExe").Value
        })
        .ToArray();
    
    foreach (var antiVirus in installedAntivirusses)
    {
        Console.WriteLine("{0}: {1}", antiVirus.Name, antiVirus.Path);
    }
