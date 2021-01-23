             XmlDocument doc = new XmlDocument();
            doc.Load("file.xml");
            //Create an XmlNamespaceManager for resolving namespaces.
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("ab", "http://www.findpersonName.com");
            MessageBox.Show(doc.SelectSingleNode("//ab:name", nsmgr).InnerText);
  
