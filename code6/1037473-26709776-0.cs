     var httpApp = sender as HttpApplication;
                var Request = httpApp.Request as HttpRequest;
                string documentContents;
                using (Stream receiveStream = Request.InputStream)
                {
                    using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                    {
                        documentContents = readStream.ReadToEnd();
                    }
                }            
                XmlDocument xd = new XmlDocument();
                xd.LoadXml(documentContents);
                XmlElement root = xd.DocumentElement;
                XmlNodeList titleList = root.GetElementsByTagName("CustID");
                return titleList[0].InnerText;         
