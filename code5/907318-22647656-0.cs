                StringWriter stringwriter = new StringWriter();
                XmlTextWriter xmlTextWriter = new XmlTextWriter(stringwriter);
                xmlTextWriter.Formatting = Formatting.Indented;
                xmlTextWriter.WriteStartDocument();           
            foreach (var match in myCollection)
            {
                xmlTextWriter.WriteStartElement(match);
                ;
                             ...
                             ...
                xmlTextWriter.WriteEndElement();
                
            }
                xmlTextWriter.WriteEndDocument();
                XmlDocument docSave = new XmlDocument();
                docSave.LoadXml(stringwriter.ToString());
                //write the path where you want to save the Xml file
                docSave.Save(AppDomain.CurrentDomain.BaseDirectory.ToString() +"Roting.xml");
