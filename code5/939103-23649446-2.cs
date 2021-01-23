    protected IAppender ParseAppender(XmlElement appenderElement)
    {
        string attribute = appenderElement.GetAttribute("name");
        string attribute2 = appenderElement.GetAttribute("type");
        // <snip>
    	try
    	{
            IAppender appender = (IAppender)Activator.CreateInstance(SystemInfo.GetTypeFromString(attribute2, true, true));
            appender.Name = attribute;
            // <snip>
