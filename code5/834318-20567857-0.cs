    private IEnumerable<Regex> ReadRegExPatterns()
    {
    	using (XmlReader reader = XmlReader.Create("RegExFormats.xml"))
    	{
    		while (reader.Read())
    		{
    			if (reader.IsStartElement())
    			{
    				if (reader.Name == "Pattern")
    				{
    					if (reader.Read())
    					{
    						yield return new Regex(reader.Value.Trim());
    					}
    				}
    			}
    		}
    	}
    }
