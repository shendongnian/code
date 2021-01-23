            var xDoc = new XDocument(
                new XDeclaration("1.0", Encoding.UTF8.ToString(), "true"),
                new XElement("root",
                    new XElement("account",
                        new XElement("systemInfo",
                            new XElement("dskInfo",
                                new XElement("dskInterface",
                                    new XElement("size", 53999759360)))))));
            var doc = new XmlDocument();
            using (var xmlReader = xDoc.CreateReader())
            {
                doc.Load(xmlReader);
            }
            XmlNodeList accountList = doc.GetElementsByTagName("account");
            foreach (XmlNode node in accountList)
            {
                XmlElement accountElement = (XmlElement)node;
                foreach (XmlElement dskInterface in node.SelectNodes("systemInfo/dskInfo/dskInterface"))
                {
                    String temp = (dskInterface["size"].InnerText).ToString();
                    long iasdas = Convert.ToInt64(temp) / 1024; // Error Happens here
                }
            }
