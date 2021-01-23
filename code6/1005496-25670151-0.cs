    object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
    AssemblyCopyrightAttribute attribute = null;
    if (attributes.Length > 0)
    {
       attribute = attributes[0] as AssemblyCopyrightAttribute;
    }
    var companyName = attribute.Company;
