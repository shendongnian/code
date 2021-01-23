    string srcFileName = pInMsg.Context.Read("ReceivedFileName", "http://schemas.microsoft.com/BizTalk/2003/file-properties This link is external to TechNet Wiki. It will open in a new window. ").ToString();
    srcFileName = Path.GetFileName(srcFileName);
    
    //Substring the first four digits to take source code to use to call BRE API
    string customerCode = srcFileName.Substring(0, 4);
    
    //create an instance of the XML object
    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.LoadXml(string.Format(@"<ns0:Root xmlns:ns0='http://TechNetWiki.SchemaResolver.Schemas.SchemaResolverBRE This link is external to TechNet Wiki. It will open in a new window. '>
        <SrcCode>{0}</SrcCode>
        <MessageType></MessageType>
        </ns0:Root>", customerCode));
    //retreive source code in case in our cache dictionary
    if (cachedSources.ContainsKey(customerCode))
    {
       messageType = cachedSources[customerCode];
    }
    else
    {
    TypedXmlDocument typedXmlDocument = new TypedXmlDocument("TechNetWiki.SchemaResolver.Schemas.SchemaResolverBRE", xmlDoc);
    Microsoft.RuleEngine.Policy policy = new Microsoft.RuleEngine.Policy("SchemaResolverPolicy");
                        policy.Execute(typedXmlDocument);
