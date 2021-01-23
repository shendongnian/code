        public CSortedList<string, CBasicStockData> Stocks { get; set; }
        public CSortedList<string, CIndustrySectorExchangeInfo> Exchanges { get; set; }
        public CSortedList<string, CIndustrySectorExchangeInfo> Industries { get; set; }
        public CSortedList<string, CIndustrySectorExchangeInfo> Sectors { get; set; }
        public void WriteXml(XmlWriter writer)
        {
            try
            {
                ///////////////////////////////////////////////////////////
                writer.WriteStartElement("Stocks");
                writer.WriteAttributeString("num", Stocks.Count.ToString());
                foreach (var kv in Stocks)
                {
                    writer.WriteStartElement("item");
                    foreach (var p in kv.Value.WritableProperties)
                    {
                        var value = p.GetValue(kv.Value);
                        var str = (value == null ? string.Empty : value.ToString());
                        writer.WriteAttributeString(p.Name, str);
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                ///////////////////////////////////////////////////////////
                foreach (var propInfo in this.WritableProperties)
                {
                    if (propInfo.Name == "Stocks") continue;
                    dynamic prop = propInfo.GetValue(this);
                    writer.WriteStartElement(propInfo.Name);
                    writer.WriteAttributeString("num", prop.Count.ToString());
                    foreach (var kv in prop)
                    {
                        writer.WriteStartElement("item");
                        foreach (var p in kv.Value.WritableProperties)
                        {
                            var value = p.GetValue(kv.Value);
                            var str = (value == null ? string.Empty : value.ToString());
                            writer.WriteAttributeString(p.Name, str);
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        public void ReadXml(XmlReader reader)
        {
            var propName = string.Empty;
            while (reader.Read() &&
                !(reader.NodeType == XmlNodeType.EndElement && reader.LocalName == this.GetType().Name))
            {
                if (reader.Name != "item")
                {
                    propName = reader.Name;
                    continue;
                }
                switch (propName)
                {
                    case "Stocks":
                        {
                            var obj = new CBasicStockData();
                            foreach (var propInfo in obj.WritableProperties)
                            {
                                var value = reader.GetAttribute(propInfo.Name);
                                if (value == null)  //we may add new property to class after the file is created
                                    continue;
                                propInfo.SetValue(obj, Convert.ChangeType(value, propInfo.PropertyType));
                            }
                            this.Stocks.Add(obj.Symbol, obj);
                            break;
                        }
                    case "Exchanges":
                    case "Industries":
                    case "Sectors":
                        {
                            var obj = new CIndustrySectorExchangeInfo();
                            foreach (var p in obj.WritableProperties)
                            {
                                var value = reader.GetAttribute(p.Name);
                                if (value == null)
                                    continue;
                                p.SetValue(obj, Convert.ChangeType(value, p.PropertyType));
                            }
                            var propInfo = this.WritableProperties.Find(x => x.Name == propName);
                            dynamic prop = propInfo.GetValue(this);
                            prop.Add(obj.Name, obj);
                            break;
                        }
                    default:
                        break;
                }
            }
        }
        public static string XML_Serialize<T>(string filename, T myObject) where T : IXmlSerializable
        {
            XmlSerializer xmlSerializer = new XmlSerializer(myObject.GetType());
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (StringWriter stringWriter = new StringWriter())
            using (XmlWriter writer = XmlWriter.Create(stringWriter, settings)) {
                xmlSerializer.Serialize(writer, myObject);
                var xml = stringWriter.ToString(); // Your xml
                File.WriteAllText(filename, xml);
                return xml;
            }
        }
        public static void XML_DeSerialize<T>(string filename, out T myObject) where T : IXmlSerializable
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StreamReader reader = new StreamReader(filename)) {
                myObject = (T)xmlSerializer.Deserialize(reader);
            }
        }
