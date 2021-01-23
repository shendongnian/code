            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<root>" +
                            "<name>" +
                                "<first>John</first>" +
                                "<last>Smith</last>" +
                            "</name>" +
                        "</root>");
            XmlNodeList liste = doc.FirstChild.SelectNodes("*/first");
            XmlNode x = liste[0];   //Some Node
            string path = "";
            while (!x.Name.Equals("document"))
            {
                path = x.Name + "\\" + path;
                x = x.ParentNode;
            }
