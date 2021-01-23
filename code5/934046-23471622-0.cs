     bool isNew = false;
        string path = Server.MapPath("~/Web.Config");
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        XmlNodeList list = doc.DocumentElement.SelectNodes(string.Format("connectionStrings/add[@name='{0}']", "conn"));
        XmlNode node;
        isNew = list.Count == 0;
        if (isNew)
        {
            node = doc.CreateNode(XmlNodeType.Element, "add", null);
            XmlAttribute attribute = doc.CreateAttribute("name");
            attribute.Value = "conn";
            node.Attributes.Append(attribute);
            attribute = doc.CreateAttribute("connectionString");
            attribute.Value = "";
            node.Attributes.Append(attribute);
            attribute = doc.CreateAttribute("providerName");
            attribute.Value = "System.Data.SqlClient";
            node.Attributes.Append(attribute);
        }
        else
        {
            node = list[0];
        }
        string conString = node.Attributes["connectionString"].Value;
        SqlConnectionStringBuilder conStringBuilder = new SqlConnectionStringBuilder(conString);
        conStringBuilder.InitialCatalog = T1.Text;
        node.Attributes["connectionString"].Value = conStringBuilder.ConnectionString;
        if (isNew)
        {
            doc.DocumentElement.SelectNodes("connectionStrings")[0].AppendChild(node);
        }
        doc.Save(path);
