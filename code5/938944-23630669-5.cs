     XmlDocument xDocument = new XmlDocument();
     xDocument.Load(@"YourXmlFile.xml");
                        
     foreach (XmlNode node in xDocument.GetElementsByTagName("Item"))
     {
          v1color.Items.Add(new ListItem(node.Attributes["ddlText"].Value));
     }
     
