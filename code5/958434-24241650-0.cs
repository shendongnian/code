    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(domainToCheckWith);
                req.Proxy = new WebProxy(proxy);
                req.Timeout = timeout;
                req.ReadWriteTimeout = readTimeout;
                req.Headers.Add(HttpRequestHeader.AcceptEncoding, "deflate,gzip");
                req.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
    
                byte[] responseByte = new byte[1024];
                string responseString = string.Empty;
    
                sw.Start();
                using (WebResponse res = req.GetResponse())
                {
                    using (Stream stream = res.GetResponseStream())
                    {
                        while (stream.Read(responseByte, 0, responseByte.Length) > 0)
                        {
                            responseString += Encoding.UTF8.GetString(responseByte);
                            if(sw.ElapsedMilliseconds > (long)timeout)
                                throw new WebException();
                        }
                        
                    }
                }
                sw.Stop();
