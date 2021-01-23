                if (!string.IsNullOrEmpty(userAuthenticationURI))
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(userAuthenticationURI);
                    request.Method = "GET";
                    request.ContentType = "application/json";
                    WebResponse response = request.GetResponse();
                    var responseString = new 
    StreamReader(response.GetResponseStream()).ReadToEnd();
                    dynamic obj = JsonConvert.DeserializeObject(responseString);
                    
                }
