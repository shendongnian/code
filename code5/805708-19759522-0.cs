            XmlDocument doc = new XmlDocument();
            doc.Load("xml path");
            XmlNode node = doc.SelectSingleNode("/Lista");
            foreach (XmlNode nodes in node.SelectNodes("Indice/@value"))
            {
                if (nodes.Value == "72")
                {
                    nodes.RemoveAll();
                }
            }
