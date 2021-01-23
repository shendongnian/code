    public async void SendData(string serviceUrl, string postData)
    {
        // parameter(s) to post
        var formData = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("DATA", postData) 
        };
    
        // assemble the request content form encoded (reference System.Net.Http), and post to the url   
        var postTask = new HttpClient().PostAsync(serviceUrl, new FormUrlEncodedContent(formData));
        HttpResponseMessage responseMessage = await postTask;
    
        // if request was succesful, extract the response
        if (responseMessage.IsSuccessStatusCode)
        {
            using (StreamReader reader = new StreamReader(await responseMessage.Content.ReadAsStreamAsync()))
            {
                // now process the response
                string serviceResponse = reader.ReadToEnd();
            }
        }
    }
