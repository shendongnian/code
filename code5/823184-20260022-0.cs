    const string xsiNamespace = System.Xml.Schema.XmlSchema.InstanceNamespace;
    const string xsdNamespace = System.Xml.Schema.XmlSchema.Namespace;
 
    public static void EnsureDefaultNamespaces(System.Xml.XmlWriter writer)
    {
       if (writer.LookupPrefix(xsiNamespace) == null)
           writer.WriteAttributeString("xmlns", "xsi", null, xsiNamespace);
       if (writer.LookupPrefix(xsdNamespace) == null)
           writer.WriteAttributeString("xmlns", "xsd", null, xsdNamespace);
    }
