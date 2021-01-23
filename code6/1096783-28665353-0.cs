    public string sendDataPost()
            {
                string url = "https://www.fshare.vn/login";
                string fsCsrf = "";
                Regex regEx = new Regex(@"<input type=""hidden"" value=""(.*)"" name=""fs_csrf"" \/>");
                
                CookieContainer cookie = new CookieContainer();
                HttpWebRequest initialRequest = (HttpWebRequest)WebRequest.Create(url);            
                initialRequest.CookieContainer = cookie;            
                HttpWebResponse getCookiesResponse = (HttpWebResponse)initialRequest.GetResponse();
                using (StreamReader sr = new StreamReader(getCookiesResponse.GetResponseStream()))
                {
                    string responseHtml = sr.ReadToEnd();
                    Match match = regEx.Match(responseHtml);
                    if (match.Groups.Count > 1)
                        fsCsrf = match.Groups[1].Value;
                }
    
                if (!string.IsNullOrEmpty(fsCsrf))
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";                                                                
                    request.CookieContainer = cookie;
    
                    string username = "user";
                    string password = "pass";
                    string postData = "fs_csrf=" + fsCsrf + "&LoginForm%5Bemail%5D=" + username + "&LoginForm%5Bpassword%5D=" + password + "&LoginForm%5BrememberMe%5D=0&yt0=%C4%90%C4%83ng+nh%E1%BA%ADp";                                
    
                    using (Stream requestStream = request.GetRequestStream())
                    using (StreamWriter requestStreamWriter = new StreamWriter(requestStream))
                    {                    
                        requestStreamWriter.Write(postData);
                        requestStreamWriter.Flush();
                        WebResponse response = request.GetResponse();                    
                        
                        using (Stream stream = response.GetResponseStream())
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            var result = reader.ReadToEnd();
                            return result;
                        }
                    }                
                }
    
                return null;
            }
