        class XmlInfo
        {
            public string XmlName {get; set;}
            public string XsdName {get; set;}
        }
        XmlInfo filename(string rate)
        {
            ...
            return new XmlInfo() { XmlName = xmlName, XsdName = xsdName };
        }
