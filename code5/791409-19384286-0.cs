    var attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
    var attribute = null;
    if (attributes.Length > 0)
    {
        attribute = attributes[0] as AssemblyCompanyAttribute;
    }
   
