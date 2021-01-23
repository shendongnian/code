    void Main() {
        XDocument xml = new XDocument(new XDeclaration("1.0", "utf-8", ""), new XElement("Root"));
        var sw = new UTF8StringWriter();
        xml.Save(sw);
        Console.WriteLine(sw.GetStringBuilder().ToString());    
    }
    
    private class UTF8StringWriter : StringWriter {
        public override Encoding Encoding { get { return Encoding.UTF8; } }
    }
