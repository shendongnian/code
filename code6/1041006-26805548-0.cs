    static void Main(string[] args)
    {
        XmlSerializer myItemSerializer = new XmlSerializer(typeof(MyItem));
        var xmlDoc = XDocument.Parse(@"<Item>
                                    <ItemHeader Attr1=""A"" Attr2=""B"" Attr3=""C"" />
                                    <ItemDetails Attr4=""D"" Attr5=""E"" />
                                </Item>");
        using (var reader = xmlDoc.CreateReader())
        {
            MyItem myItem = (MyItem)myItemSerializer.Deserialize(reader);
        }
            
        Console.Read();
    }
    [Serializable, XmlRoot("Item")]
    public class MyItem : IXmlSerializable
    {
        [XmlAttribute("Attr1")]
        public string Attr1 { get; set; }
        [XmlAttribute("Attr5")]
        public string Attr5 { get; set; }
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            reader.ReadStartElement("Item");
            do
            {
                switch (reader.Name)
                {
                    case "ItemHeader":
                        Attr1 = reader.GetAttribute("Attr1");
                        reader.Read();
                        break;
                    case "ItemDetails":
                        Attr5 = reader.GetAttribute("Attr5");
                        reader.Read();
                        break;
                    default:
                        throw new XmlException(String.Format("{0} was not expected", reader.Name));
                }
            } while (reader.Name != "Item");
                
            reader.ReadEndElement();
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("ItemHeader");
            writer.WriteAttributeString("Attr1", Attr1);
            writer.WriteEndElement();
            writer.WriteStartElement("ItemDetails");
            writer.WriteAttributeString("Attr5", Attr5);
            writer.WriteEndElement();
        }
    }
