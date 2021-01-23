    System.Net.ServicePointManager.Expect100Continue = false;
                    byte[] requestData = Encoding.ASCII.GetBytes("<?xml version=\"1.0\"?><methodCall><methodName>system.listMethods</methodName></methodCall>");
        
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://ip/RPC2");
                    request.Method = "POST";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; .NET CLR 1.1.4322; .NET CLR 2.0.50727; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729;)";
                    request.ContentType = "text/xml";
                    request.ContentLength = requestData.Length;
        
                    using (Stream requestStream = request.GetRequestStream())
                        requestStream.Write(requestData, 0, requestData.Length);
        
                    string result = null;
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(stream, Encoding.ASCII))
                                result = reader.ReadToEnd();
                        }
                    }
