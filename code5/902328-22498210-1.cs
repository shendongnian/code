    Dictionary<string, int[]> keyIndexCollection = new Dictionary<string, int[]>();
    XmlDocument doc = new XmlDocument();
    doc.Load("input.xml");
    XmlNodeList keyNodeList = doc.SelectNodes("root/key");
    List<int> indexValues = new List<int>();
    foreach (XmlNode node in keyNodeList)
    {
    	XmlNodeList indexNodeList = node.SelectNodes("Index");
    	int parsedIndex;
    	indexValues.Clear();
    	foreach (XmlNode indexNode in indexNodeList)
    	{
    		if (int.TryParse(indexNode.InnerText, out parsedIndex))
    		{
    			indexValues.Add(parsedIndex);
    		}
    	}
    
    	keyIndexCollection.Add(node.Attributes["value"].Value, indexValues.ToArray());
    }
