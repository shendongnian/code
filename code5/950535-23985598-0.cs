    Uri uri =  new Uri("api.flickr.com");
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
    request.Method = "POST";
    
    //goes into the body. not header
    NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
    queryString["api_key"] = "7d44e178b0434";
    ...
    
    object returnValue = null;
     try
                {
                    using (var writer = new StreamWriter(request.GetRequestStream()))
                    {
                        writer.WriteLine(queryString);
                    }
                    
                    returnValue = request.GetResponse();
                }
                catch (Exception ex)
                {
                   ..
                }
