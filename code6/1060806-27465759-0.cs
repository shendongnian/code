      public bool IsNodeExist(string  fileName)
        {
            bool bState = false;
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            //Select the node with the matching attribute value.
            XmlNode nodeToFind;
            XmlNamespaceManager namespaceManager = new XmlNamespaceManager(doc.NameTable);
           
            namespaceManager.AddNamespace("cdsd", "cds_dt");
            namespaceManager.AddNamespace("cds", "cds");
            nodeToFind =     doc.DocumentElement.SelectSingleNode("./cds:PatientRecord/cds:Demographics/cds:DateOfBirth", namespaceManager);
            
            if (nodeToFind == null)
            {
                bState = true;
            }
            return bState;
        }
