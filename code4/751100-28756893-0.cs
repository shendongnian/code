    //The below code worked for me. I receive xml response back. 
    private void SendDataUsingHttps()
    {                   
         WebRequest req = null;       
         WebResponse rsp = null;
         string fileName = @"C:\Test\WPC\InvoiceXMLs\123File.xml";                  string uri = "https://service.XYZ.com/service/transaction/cxml.asp";
                try
                {
                    if ((!string.IsNullOrEmpty(uri)) && (!string.IsNullOrEmpty(fileName)))
                    {
                        req = WebRequest.Create(uri);
                        //req.Proxy = WebProxy.GetDefaultProxy(); // Enable if using proxy
                        req.Method = "POST";        // Post method
                        req.ContentType = "text/xml";     // content type
                        // Wrap the request stream with a text-based writer                  
                        StreamWriter writer = new StreamWriter(req.GetRequestStream());
                        // Write the XML text into the stream
                        StreamReader reader = new StreamReader(file);
                        string ret = reader.ReadToEnd();
                        reader.Close();
                        writer.WriteLine(ret);
                        writer.Close();
                        // Send the data to the webserver
                        rsp = req.GetResponse();
                        HttpWebResponse hwrsp = (HttpWebResponse)rsp;
                        Stream streamResponse = hwrsp.GetResponseStream();
                        StreamReader streamRead = new StreamReader(streamResponse);
                        string responseString = streamRead.ReadToEnd();                    
                        rsp.Close();
                    }
                }
                catch (WebException webEx) { }
                catch (Exception ex) { }
                finally
                {
                    if (req != null) req.GetRequestStream().Close();
                    if (rsp != null) rsp.GetResponseStream().Close();
                }
    
    }
