    var overrides = new XmlAttributeOverrides();
    overrides.Add(typeof(SubmitObjectsRequest), "RegistryObjectList", new XmlAttributes
    {
        XmlArray = new XmlArrayAttribute()
        {
            Namespace = "urn:oasis:names:tc:ebxml-regrep:xsd:rim:3.0",
            Order = 0
        },
        XmlArrayItems =
        {
            new XmlArrayItemAttribute("ExtrinsicObject", typeof(ExtrinsicObjectType)) { IsNullable = false },
            new XmlArrayItemAttribute("RegistryPackage", typeof(RegistryPackageType)) { IsNullable = false }
        }
    });
