    Nested n = new Nested();
    n.Nest = "2";
    n.F1 = null;
    
    XmlAttributeOverrides overrides = new XmlAttributeOverrides();
    
    XmlAttributes att = new XmlAttributes();
    XmlElementAttribute el = new XmlElementAttribute("F1");
    el.IsNullable = true;
    att.XmlElements.Add(el);
    overrides.Add(typeof(Nested), "F1", att);
    XmlSerializer xs = new XmlSerializer(typeof(Nested));
    
    var faultDocument = new XmlDocument();
    var nav = faultDocument.CreateNavigator();
    StringWriter strWriter = new StringWriter();
    XmlTextWriter TextWriter = new XmlTextWriter(strWriter);
    var ns = new XmlSerializerNamespaces();
    ns.Add("", "");
    xs.Serialize(TextWriter, n, ns);
    ReqXml = strWriter.ToString();
    TextWriter.Close();
    return ReqXml;
