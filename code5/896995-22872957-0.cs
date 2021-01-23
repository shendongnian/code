    /// <summary>
    /// Send the log message to loggly
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    private void SendMessage(LogMessageEnvelope message)
    {
        // build list of tags
        string tags = string.Join(",", message.MessageTags); 
        // serialize the message
        JsonSerializerSettings settings = new JsonSerializerSettings 
        { 
            NullValueHandling = NullValueHandling.Ignore,
        };
        string content = 
            JsonConvert.SerializeObject(message, Formatting.Indented, settings);
        // build the request
        HttpRequestMessage request = new HttpRequestMessage();
        request.RequestUri = new Uri(logglyUrl);
        request.Method = HttpMethod.Post;
        request.Content = new StringContent(content, Encoding.UTF8);
        request.Headers.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        request.Headers.Add("X-LOGGLY-TAG", tags);
        
        // send the request
        HttpClient client = new HttpClient();
        client.SendAsync(request)
              .ContinueWith(sendTask =>
                {
                    // handle the response
                    HttpResponseMessage response = sendTask.Result;
                    if (!response.IsSuccessStatusCode)
                        // handle a failed log message post
                });
    }
