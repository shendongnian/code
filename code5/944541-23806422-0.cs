    TextWriter tw = new StreamWriter (wxsBundleFileName) ;
    System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(wx.GetType());
    
    XmlSerializerNamespaces XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
    ns.Add("", " http://schemas.microsoft.com/wix/2006/wi");
    ns.Add("bal", "http://schemas.microsoft.com/wix/BalExtension") ;
    
    xs.Serialize(tw, wx, ns);
