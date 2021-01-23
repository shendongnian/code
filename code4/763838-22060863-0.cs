     ItemType itemType = new ItemType()
     {
         //populate data.
     };
     ApiCall apiCall = new AddItemCall() { Item = itemType };
     AddItemRequestType addFixedPriceItemRequestType = ((AddItemCall)apiCall).ApiRequest;
     XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new XmlQualifiedName[] {
         new XmlQualifiedName(string.Empty, "urn:ebay:apis:eBLBaseComponents")});
     XmlSerializer xmlSerializer = new XmlSerializer(
         addFixedPriceItemRequestType.GetType(), "urn:ebay:apis:eBLBaseComponents");
     MemoryStream memoryStream = new MemoryStream();
     xmlSerializer.Serialize(memoryStream, addFixedPriceItemRequestType , namespaces);
     memoryStream.Seek((long)0, SeekOrigin.Begin);
     XmlDocument xmlDocument = new XmlDocument();
     xmlDocument.Load(memoryStream);
     memoryStream.Close();
     string addItemRequestTypeXML = xmlDocument.OuterXml;
