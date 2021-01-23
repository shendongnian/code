          static CookieContainer cookies = new CookieContainer();
    
            static HttpWebRequest GetNewRequest(string targetUrl, CookieContainer SessionCookieContainer)
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(targetUrl);
                request.CookieContainer = SessionCookieContainer;
                request.AllowAutoRedirect = false;
                return request;
            }
    
            public static HttpWebResponse MakeRequest(HttpWebRequest request, CookieContainer SessionCookieContainer, Dictionary<string, string> parameters = null)
            {
    
    
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/536.5 (KHTML, like Gecko) Chrome/19.0.1084.52 Safari/536.5Accept: */*";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                request.CookieContainer = SessionCookieContainer;
                request.AllowAutoRedirect = false;
    
                if (parameters != null)
                {
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    string postData = "";
                    foreach (KeyValuePair<String, String> parametro in parameters)
                    {
                        if (postData.Length == 0)
                        {
                            postData += String.Format("{0}={1}", parametro.Key, parametro.Value);
                        }
                        else
                        {
                            postData += String.Format("&{0}={1}", parametro.Key, parametro.Value);
                        }
    
                    }
                    byte[] postBuffer = UTF8Encoding.UTF8.GetBytes(postData);
                    using (Stream postStream = request.GetRequestStream())
                    {
                        postStream.Write(postBuffer, 0, postBuffer.Length);
                    }
                }
                else
                {
                    request.Method = "GET";
                }
    
    
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                SessionCookieContainer.Add(response.Cookies);
    
    
                while (response.StatusCode == HttpStatusCode.Found)
                {
                    response.Close();
                    request = GetNewRequest(response.Headers["Location"], SessionCookieContainer);
                    response = (HttpWebResponse)request.GetResponse();
                    SessionCookieContainer.Add(response.Cookies);
                }
    
    
                return response;
            }
