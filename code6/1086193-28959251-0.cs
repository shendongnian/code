                try
                {
                    var httpRequest = WebRequest.CreateHttp(Protocol + ServerUrl + ":" + ServerPort + ServerAppName + url);
    
                    if (HttpWebRequest.DefaultMaximumErrorResponseLength < int.MaxValue)
                        HttpWebRequest.DefaultMaximumErrorResponseLength = int.MaxValue;
    
                    httpRequest.ContentType = "application/json";
                    httpRequest.Method = method;
                    var encoding = Encoding.GetEncoding("utf-8");
                   
                    if (httpRequest.ServicePoint != null)
                    {
                        httpRequest.ServicePoint.ConnectionLeaseTimeout = 5000;
                        httpRequest.ServicePoint.MaxIdleTime = 5000;
                    }
                    //----HERE--
                    httpRequest.KeepAlive = true;
                    //----------
                    using (var response = await httpRequest.GetResponseAsync(token))
                    {
                        using (var reader = new StreamReader(response.GetResponseStream(), encoding))
                        {                       
                            return await reader.ReadToEndAsync();
                        }
                    }
                }
                catch (WebException ex)
                {
                    if (ex.Status == WebExceptionStatus.ProtocolError)
                    {
                        using (var response = (HttpWebResponse)ex.Response)
                        {
                            using (var stream = response.GetResponseStream())
                            {
                                using (var reader = new StreamReader(stream, Encoding.GetEncoding("utf-8")))
                                {
                                    return reader.ReadToEnd();
                                    //or handle it like you want
                                }
                            }
                        }
                    }
                }
