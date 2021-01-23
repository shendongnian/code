    var postRequest = (HttpWebRequest)WebRequest.Create(url);               
    postRequest.Method = "GET";                
    postRequest.CookieContainer = new CookieContainer();;
               
    HttpWebResponse postResponse = (HttpWebResponse)await postRequest.GetResponseAsync();
    if (postResponse != null)
    {
       var postResponseStream = postResponse.GetResponseStream();
       var postStreamReader = new StreamReader(postResponseStream);
       string response = await postStreamReader.ReadToEndAsync();
        return response;// This is the response
    }
