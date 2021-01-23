    string message = "<Insert XML Here>";
    string findrunner = "123";
    XmlDocument document = new XmlDocument();
    document.LoadXml(message);
    XmlNodeList nodelist = document.SelectNodes("//Runner");
    
    foreach (XmlNode node in nodelist)
    {
    	foreach (XmlNode child in node.ChildNodes)
    	{
     		if (child.Name == "RunnersBadge" && child.InnerText.Equals(findrunner))
     		{
     			XmlNode Times = null;
     			XmlNode LapTime = null;
     			if ((Times = node.SelectSingleNode("//Times")) == null)
     			{
     				Times = document.CreateNode(XmlNodeType.Element, "Times", "");
     				node.AppendChild(Times);
     			}
     			LapTime = document.CreateNode(XmlNodeType.Element, "LapTime", "");
			    LapTime.InnerText = ""; // Set Value Here
			    Times.AppendChild(LapTime);
			    break;
		    } 	  
        } 
    }
