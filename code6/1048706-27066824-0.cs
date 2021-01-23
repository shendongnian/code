    //Get Message 
    //txtsearch text u have to pass message Id
               var xmlFilePath = Server.MapPath("Test.xml");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlFilePath);
           
                XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/TableMessage/Message");
                string msgID = "",msgname="";
                foreach (XmlNode node in nodeList)
                {
                    if (node.SelectSingleNode("Message_Details").InnerText == "True" && node.SelectSingleNode("Message_id").InnerText==txtsearchtext.Text)
                    {
                        msgID = node.SelectSingleNode("Message_id").InnerText;
                        msgname = node.SelectSingleNode("Message_name").InnerText;
                     
                    }
                   
                                   
                    
                }
    //store Updated Xml in ur project  xml
    //get the information from end user and pass the value to correspoding fields
               XmlDocument xmlEmloyeeDoc = new XmlDocument();
                xmlEmloyeeDoc.Load(Server.MapPath("~/Test.xml"));
                XmlElement ParentElement = xmlEmloyeeDoc.CreateElement("Message");
                XmlElement ID = xmlEmloyeeDoc.CreateElement("Message_id");
                ID.InnerText = "6";
                XmlElement message = xmlEmloyeeDoc.CreateElement("Message_name");
                message.InnerText = "Message6";
                XmlElement Details = xmlEmloyeeDoc.CreateElement("Message_Details");
                Details.InnerText = "True";
                ParentElement.AppendChild(ID);
                ParentElement.AppendChild(message);
                ParentElement.AppendChild(Details);     
                xmlEmloyeeDoc.DocumentElement.AppendChild(ParentElement);
                xmlEmloyeeDoc.Save(Server.MapPath("~/Test.xml"));
    I hope that code will help u
