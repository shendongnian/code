        XmlDocument doc = new XmlDocument();
        doc.Load("yourXml.xml");
        XmlNodeList nodes = doc.GetElementsByTagName("book");
        for (int i = nodes.Count - 1; i >= 0; i--)
        {
            string price = nodes[i]["price"].InnerText;
            if (string.IsNullOrEmpty(price))
            {
                nodes[i].ParentNode.RemoveChild(nodes[i]);
            }
        }
        doc.Save("yourXml.xml");
