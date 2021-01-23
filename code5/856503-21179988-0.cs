                string FileContent = string.Empty;
 
                using (StreamReader Reader = new StreamReader(**FilePath**, UTF8Encoding.UTF8))
                {
                    FileContent = Reader.ReadToEnd();
                }
                XmlDocument XDoc = new XmlDocument();
                XDoc.LoadXml(FileContent); //Load the file with XML strcuture
                XDoc.SelectNodes("/**NodeNameToSelect**");
                
                // Read inner text of the XDocument's Child Elements
                string Result = XDoc["**ChildNodeName**"].InnerText;
