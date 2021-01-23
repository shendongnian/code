        Uri address = new Uri(http://google.com/");               
                // Create the web request 
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);  
                // Set type to POST  ;
                
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
          
                
                    request.Proxy = new WebProxy("ProxyIP", "Port");
                    request.Proxy.Credentials = new NetworkCredential("ProxyUsername", "ProxyPassword");
               
                                // Write data  
                using (Stream postStream = request.GetRequestStream())
                {
                    postStream.Write(byteData, 0, byteData.Length);
                }
               
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader StreamReader = new StreamReader(response.GetResponseStream());
                    string strReaderXML = StreamReader.ReadToEnd();
                          
                }
