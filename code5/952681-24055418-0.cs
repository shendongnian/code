    public void multipleXML()
            {
                XmlNode countNode = HandlingXmlDoc.CreateNode(XmlNodeType.Element, "Count", null);
    
                XmlNode productIdentifierNode = HandlingXmlDoc.CreateNode(XmlNodeType.Element, "ProductIdentifier", null);
                productIdentifierNode.InnerText = "123345";
    
                XmlNode countDateTimeNode = HandlingXmlDoc.CreateNode(XmlNodeType.Element, "CountDateTime", null);
                countDateTimeNode.InnerText = DateTime.Now.ToString();
    
                //XmlNode locationCountNode = HandlingXmlDoc.CreateNode(XmlNodeType.Element, "LocationCounts", null);
    
                countNode.AppendChild(productIdentifierNode);
                countNode.AppendChild(countDateTimeNode);
                var test = SetNewLocation("Bangalore", "30", "30");
                countNode.AppendChild(countNode.OwnerDocument.ImportNode(test, true));
                
                //countNode.AppendChild(test);//ERROR
    
                HandlingXmlDoc.SelectSingleNode("//SHandling//Counting//Counts").AppendChild(countNode);
    
    
            }
