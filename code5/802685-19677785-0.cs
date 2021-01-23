                string xml = @"<?xml version='1.0' encoding='UTF-8'?>
                                <configuration>
                                  <ConfigSection>
                                    <GeneralParams>
                                      <parameter key='TableName' value='MyTable1' />
                                    </GeneralParams>
                                  </ConfigSection>
                                </configuration>";
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(xml);
    
                XmlNode paramter;
                XmlNode root = xDoc.DocumentElement;
    
                paramter = xDoc.SelectSingleNode("//parameter/@key");
                paramter.LastChild.InnerText = "MyTable2";
    
                string modifiedxml = xDoc.OuterXml;
