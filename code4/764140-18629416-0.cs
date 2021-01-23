    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader("c:\\YourXmlFile.xml");
         string contents = "";
         while (reader.Read()) 
         {
            reader.MoveToContent();
            if (reader.NodeType == System.Xml.XmlNodeType.Element)
               contents += "<"+reader.Name + ">\n";
            if (reader.NodeType == System.Xml.XmlNodeType.Text)
               contents += reader.Value + "\n";
         }
     Console.Write(contents);
