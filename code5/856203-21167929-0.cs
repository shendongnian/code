    public static class XMLStringExtensions
    {
    	public static string LastTag(this string innerXml, string tag)
    	{
    		string previousTag = null;
    		using (var reader = XmlReader.Create(new StringReader(innerXml.WrapInRoot())))
    			while(reader.ReadToFollowing(tag)) previousTag = reader.ReadOuterXml();
    		return previousTag;
    	}
    	
    	public static string WrapInRoot(this string partialXml)
    	{
    		return string.Format("<root>{0}</root>", partialXml);
    	}
    }
