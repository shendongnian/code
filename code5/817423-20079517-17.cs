    public void Save(string targetXmlFileName = null)
    {
                XDocument doc = new XDocument();
                XElement root = new XElement("TopLevel");
    
                //Add the root to the XML document
                doc.Add(root);
    
                //Add all of the subitems records to the XML document
                root.Add(_midLevelItem
                    .Select(item => item.MidLevelItemFromXml())
                    .ToArray());
    
                var settings = new XmlWriterSettings()
                {
                    CloseOutput = true,
                    Indent = true,
                    Encoding = Encoding.UTF8
                };
    
                // Write the XML file
                using (XmlWriter writer = XmlWriter.Create(targetXmlFileName ?? DefaultFile, settings))
                {
                    doc.Save(writer);
                }
    }
