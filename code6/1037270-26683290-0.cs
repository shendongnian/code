    var dir = Directory.GetFiles(string.Format("{0}/Views", HostingEnvironment.ApplicationPhysicalPath), 
        "*.cshtml", SearchOption.AllDirectories);
    foreach (var file in dir)
    {
        var relativePath = file.Replace(HostingEnvironment.ApplicationPhysicalPath, String.Empty);
        Type type = BuildManager.GetCompiledType(relativePath);
        var modelProperty = type.GetProperties().FirstOrDefault(p => p.Name == "Model");
        if (modelProperty != null && modelProperty.PropertyType == typeof(LoginViewModel))
        {
            // You got the correct type
        }
    }
