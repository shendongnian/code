    public struct Money : IXmlSerializable
        {
            public double Amount { get; set; }
            public string CurrencyCode { get; set; }
    
            public System.Xml.Schema.XmlSchema GetSchema()
            {
                return (null);
            }
    
            public void ReadXml(System.Xml.XmlReader reader)
            {
                reader.MoveToContent();
    
                Boolean isEmptyElement = reader.IsEmptyElement; // (1)
                reader.ReadStartElement();
                if (!isEmptyElement) // (1)
                {
                    var str = reader.ReadContentAsString();
                    string[] sa = str.Split(' ');
                    Amount = double.Parse(sa[0]);
                    CurrencyCode = sa[1];
                    reader.ReadEndElement();
                }
            }
    
            public void WriteXml(System.Xml.XmlWriter writer)
            {
                writer.WriteString(Amount + " " + CurrencyCode);
            }
        }
