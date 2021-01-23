     foreach (XmlNode node in nodes) 
     {
          XmlDocument innerXmlDoc = new XmlDocument();
          innerXmlDoc.LoadXml(node.InnerXml);
          var list  = innerXmlDoc.GetElementsByTagName("Counters");
          for (int i = 0; i < list.Count; i++)
          {
             string val = list[i].Attributes["total"].Value;
          }
     };
