    public async Task RemoteInsert()
    {
        String dataSet = "dataset=" + json.ToString();
        accessKey = mobRemoteDB.accessKey;
        String paramaters = "?llcommand=sndmsg&" + "ak=" + accessKey + "&command=remoteinsert&" + dataSet;
        String url = mobRemoteDB.baseUrlForRemoteInsert + paramaters;
        HttpWebRequest webRequest = (HttpWebRequest)System.Net.WebRequest.Create(url);
        webRequest.Method = "POST";
        webRequest.ContentType = "application/json"; 
    
        if (NetworkInterface.GetIsNetworkAvailable() && IsDataValid)
        {
            // Await the GetResponseAsync() call.
            using(var response = await webRequest.GetResponseAsync().ConfigureAwait(false))
            {
                // The following code will execute on the main thread.
                using (var streamResponse = response.GetResponseStream())
                {
                    using (StreamReader streamReader = new StreamReader(streamResponse))
                    {
                        JObject json_response = JObject.Parse(streamReader.ReadToEnd());
                        String key = (String)json_response["ret"];
                        JObject dic = (JObject)json_response["retdic"];
                    }
                }
            }
        }
    }
