            XmlDocument doc = new XmlDocument();
            doc.Load("products.xml");
            XmlNodeList products = doc.GetElementsByTagName("product");
            XmlDocument output = new XmlDocument();
            XmlElement root = output.CreateElement("root");
            output.AppendChild(root);
            foreach(XmlNode e in products)
            {
                if (Double.Parse(e.ChildNodes[2].InnerText) <= 5)
                {
                    XmlNode imported = output.ImportNode(e, true);
                    root.AppendChild(imported);
                }
            }
            output.Save("found.xml");
