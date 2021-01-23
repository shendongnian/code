        XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(Server.MapPath("~/Book.xml"));
            XmlNode node;
            node = myXmlDocument.DocumentElement;
            foreach (XmlNode node1 in node.ChildNodes)
            {
                if (node1.Name == "date")
                {
                    node1.Attributes["year"].Value = "2005";
                }
            }
            myXmlDocument.Save(Server.MapPath("~/Book1.xml"));
