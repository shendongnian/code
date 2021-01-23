            XmlDocument doc = new XmlDocument();
            doc.Load(@"E:\Test.xml");
 
            XmlNodeList elementList = doc.GetElementsByTagName("node");
            for (int i = 0; i < elementList.Count; i++)
            {
                if (elementList[0].Attributes["modelDescription"].Value == "My Model Description")
                {
                    elementList[0].Attributes["modelDescription"].Value = elementList[1].Attributes["modelDescription"].Value;
                    
                    XmlAttribute newAttribute1 = doc.CreateAttribute("instanceName");
                    newAttribute1.Value = elementList[1].Attributes["instanceName"].Value;
                    elementList[0].Attributes.Append(newAttribute1);
                    XmlAttribute newAttribute2 = doc.CreateAttribute("modelCatalogNum");
                    newAttribute2.Value = elementList[1].Attributes["modelCatalogNum"].Value;
                    elementList[0].Attributes.Append(newAttribute2);
                    elementList[1].ParentNode.Attributes.Remove(elementList[0].Attributes["quantity"]);
                    
                    elementList[0].FirstChild.RemoveAll();
                }
            }
            doc.Save(@"E:\Test1.xml");  
