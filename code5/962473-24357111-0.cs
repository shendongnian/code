    private void AddNewService()
    {
        string strPath = "ServicesToExecute.xml";
        string strServicename = tbNewService.Text;
        //try
        //{
            XDocument xdDocument;
            using (XmlReader xmlReader = XmlReader.Create(strPath))
            {
                xdDocument = XDocument.Load(xmlReader); 
                XElement root = new XElement("Service");
                root.Add(new XElement("Name", strServicename));
                xdDocument.Element("ServicesToExecute").Add(root);
                // I'm not sure that the close here is sufficient to release the file lock
                xmlReader.Close();
            }
            // Save after using statement
            xdDocument.Save(strPath);      
