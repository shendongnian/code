    ...    
    if (NetworkInterface.GetIsNetworkAvailable() && IsDataValid)
    {
        // Await the GetResponseAsync() call.
        using(var response = webRequest.GetResponseAsync().Result)
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
