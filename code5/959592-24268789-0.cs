    public async Task<string> doPost(string url, Dictionary<string, string> parametros)
    {
    System.Uri myUri = new System.Uri(url);
    HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create(myUri);
    myRequest.Method = "POST";
    myRequest.ContentType = "application/x-www-form-urlencoded";
    
    //relleno variable con los parametros
    foreach (KeyValuePair<string, string> D in parametros)
    {
    parametrosData = parametrosData + D.Key + "=";
    parametrosData = parametrosData + D.Value + "&";
    }
    
    Stream postStream = await myRequest.GetRequestStreamAsync();
    // Create the post data
    string postData = parametrosData;
    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
    
    // Add the post data to the web request
    postStream.Write(byteArray, 0, byteArray.Length);
    postStream.Close();
    
    // Start the web request
    HttpWebResponse response = await myRequest.GetResponseAsync();
    string result;
    using (StreamReader httpWebStreamReader = new StreamReader(response.GetResponseStream()))
    {
     result = httpWebStreamReader.ReadToEnd();
    //For debug: show results
    Debug.WriteLine(result);
    }
    return result;
    }
