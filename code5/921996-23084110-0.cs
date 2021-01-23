           Lets consider your xml document as XYZ.xml, then you may try below code if you are using C#, below is the example only
           XmlDocument Doc = new XmlDocument();
            Doc.Load(Server.MapPath(".../xyz.xml"));
             XmlNodeList itemList = Doc.DocumentElement.SelectNodes("KEY");
             foreach (XmlNode currNode in itemList)
             {
                 string name = string.Empty; 
                 XmlNode item = currNode.SelectSingleNode("KEY");
                 if(currNode["name"].InnerText == "username")//if you are aware of key name, use this       condition
                 {
                   name = item.Attributes["name"].Value.ToString(); // or currNode["name"].InnerText;
                 }
              }
