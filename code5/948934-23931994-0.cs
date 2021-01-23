        XmlDocument doc = new XmlDocument();
        XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
        doc.AppendChild(docNode);
        
        XmlNode CustomContact Node = doc.CreateElement("CustomContact");
        doc.AppendChild(CustomContactNode);
        XmlNode CustomContactNode = doc.CreateElement("Name ");
        XmlAttribute CustomContactAttribute = doc.CreateAttribute("Name");
        XmlNode CustomNumberNode = doc.CreateElement("Number");        
        XmlAttribute CustomNumberAttribute = doc.CreateAttribute("Number");
        Foreach(customer in customers)
         {		
         
          
         CustomContactAttribute.Value = custome.Name;
         CustomContactNode.Attributes.Append(CustomContactAttribute);
         CustomContactNode.AppendChild(CustomContactNode);
         
         CustomNumberAttribute.Value = custome.Number;
         CustomContactNode.Attributes.Append(CustomContactAttribute);
         CustomContactNode.AppendChild(CustomNumberAttribute);
         
         }
