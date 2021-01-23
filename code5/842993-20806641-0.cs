    public string GetIDValue(XDocument xDoc)
    {
        foreach (var element in xDoc.Root.Elements("word"))
        {
    		if (element.Value == "this")
    		{	
    			return element.Attribute("id").Value;
    		}
        }
    }
