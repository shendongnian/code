    for (int i = 0; i < split.Length; i++)
    {
    	var s = split[i];
    	var s2 = split2[i];
    
    	//the rest of code below remain untouched
    	if (s != "")
    		if (s2 != "")
    		{
    			string str = s;
    			string str2 = str.Replace("&", "&amp");
    			string strx = s2;
    			string str3 = strx.Replace("&", "&amp");
    
    			if (File.Exists(strFilename))
    			{
    				xmlDoc.Load(strFilename);
    				XmlElement elmXML = xmlDoc.CreateElement("Student");
    				string strNewPending = "<Name>" + str2 + "</Name>" +
    									  "<Address>" + str3 + "</Address>";
    				elmXML.InnerXml = strNewPending;
    				xmlDoc.DocumentElement.AppendChild(elmXML);
    				xmlDoc.Save(strFilename);
    			}
    			else
    			{
    				//if file is not found, create a new xml file*/
    				XmlTextWriter xmlWriter = new XmlTextWriter(strFilename, System.Text.Encoding.UTF8);
    				xmlWriter.Formatting = System.Xml.Formatting.Indented;
    				xmlWriter.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");
    				xmlWriter.WriteStartElement(strFilename);
    				xmlWriter.Close();
    				xmlDoc.Load(strFilename);
    				XmlNode Clients = xmlDoc.DocumentElement;
    				XmlElement childNode = xmlDoc.CreateElement("Student");
    				XmlElement childNode2 = xmlDoc.CreateElement("Name");
    				XmlElement childNode3 = xmlDoc.CreateElement("Address");
    
    				XmlText Namex = xmlDoc.CreateTextNode("Name");
    				XmlText Addressx = xmlDoc.CreateTextNode("Address");
    
    				Namex.Value = str2;
    				Addressx.Value = str3;
    				Clients.AppendChild(childNode);
    				childNode.AppendChild(childNode2);
    				childNode.AppendChild(childNode3);
    				childNode2.AppendChild(Namex);
    				childNode3.AppendChild(Addressx);
    				xmlDoc.Save(strFilename);
    			}
    		}
    }
