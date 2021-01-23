    XmlAttributes xa = new XmlAttributes();
    XmlAttributes ya = new XmlAttributes();
    xa.XmlAttribute = new XmlAttributeAttribute("X");
    ya.XmlAttribute = new XmlAttributeAttribute("Y");
    XmlAttributeOverrides xao = new XmlAttributeOverrides();
    xao.Add(typeof(System.Windows.Point), "X", xa);
    xao.Add(typeof(System.Windows.Point), "Y", ya);
    var serializer = new XmlSerializer(typeof(RootClass), xao);
    TextReader textReader = new StreamReader("file.xml");
    var result = (RootClass)serializer.Deserialize(textReader);
    
