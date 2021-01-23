    String sampleXml = "<jobs><Table><title><![CDATA[ Country ]]></title> <category><![CDATA[ Site Engineering / Project Management ]]></category> <description><![CDATA[ sades ]]></description> </Table></jobs>";
    
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(sampleXml);
    
                XmlNode rootE = xmlDoc.GetElementsByTagName("jobs")[0];
                XmlNode oldE = rootE.SelectSingleNode("Table");
                XmlNode newE = xmlDoc.CreateElement("job");
                rootE.ReplaceChild(newE, oldE);
                while (oldE.ChildNodes.Count != 0)
                {
                    newE.AppendChild(oldE.ChildNodes[0]);
                }
                while (oldE.Attributes.Count != 0)
                {
                    newE.Attributes.Append(oldE.Attributes[0]);
                }
