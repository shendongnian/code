            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigFile);
            XmlNamespaceManager xmlnsm = new XmlNamespaceManager(xmlDoc.NameTable);
            xmlnsm.AddNamespace("h", "urn:nhibernate-configuration-2.2");
            XmlElement root = xmlDoc.DocumentElement;
            //Do you XML magic here with namespace included
            XmlNodeList Properties = root.SelectNodes("h:session-factory/h:property[@name='connection.connection_string']", xmlnsm);
