    from e2 in xdoc.Elements("GISImportConfig").Elements("BaseMapLayers").Elements("WMServer")
    select new
    {
        Url = (string)e2.Attribute("url"),
        Enabled = (string)e2.Attribute("enabled"),
        UserName = (string)e2.Attribute("username"),
        Pasword = (string)e2.Attribute("password"),
        Layers = e2.Elements("WMLayer")
    };
