            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(@"<?xml version='1.0' encoding='utf-16' ?> <Parent><ServiceList /><VoiceList /><SMSList> <SMS> <Code>ZOOMLA</Code> <Name>Zoom Limited</Name> <SubType>Prepaid</SubType> <Fields><Field><ID>222</ID> <Name>Charges</Name> <CValue>1</CValue> <Priority>0</Priority></Field></Fields></SMS></SMSList><DataList /> <LBCOffer /> </Parent>");
            XmlNode xNode = xmlDoc.SelectSingleNode("/Parent/SMSList/SMS[Code='ZOOMLA']");
            xNode.ParentNode.RemoveChild(xNode);
            XmlDocument xvDoc = xmlDoc;
