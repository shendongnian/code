     private XmlNode SetNewLocation(String location, String casesQuantity, String singlesQuantity)
            {
                XmlDocument docCountXml = new XmlDocument();
                docCountXml.LoadXml(baseLocCountXML);
    
                SetValue(docCountXml, "LocationCount/Name", location);
    
                var xmlNodeList = docCountXml.SelectNodes("LocationCount/SCounts/SCount/Quantity");
                xmlNodeList[0].FirstChild.Value = casesQuantity;
                xmlNodeList[1].FirstChild.Value = singlesQuantity;
    
                return docCountXml.SelectSingleNode("LocationCount");
            }
