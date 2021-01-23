    foreach (XmlNode node in nodeList)
    {
        
        string json;
        if (node.SelectNodes("Item").Count == 1)
        {
            // Append a dummy node and then strip it out - horrible!
            node.AppendChild(xmlDoc.CreateNode("element", "Item", ""));
            json = Newtonsoft.Json.JsonConvert.SerializeXmlNode(node).Replace(",null]", "]");
        }
        else
        {
            json = Newtonsoft.Json.JsonConvert.SerializeXmlNode(node);                    
        }
        jarray.Add(JObject.Parse(json));
    }
