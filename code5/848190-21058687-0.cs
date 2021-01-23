    using System.Net.Http;
    
    public OAuthToken GetRequestToken(Uri baseUri, string consumerKey, string consumerSecret)
    {
        var uri = new Uri(baseUri, "oauth/request_token");
        uri = SignRequest(uri, consumerKey, consumerSecret);
    
        var message = new HttpRequestMessage(new HttpMethod("GET"), uri);
        var handler = new WebRequestHandler();
        var client = new HttpClient(handler);
    
        // Use the http client to send the request to the server.
        Task<HttpResponseMessage> responseTask = client.SendAsync(message);
                
        // The responseTask object is like a wrapper for the other task thread.
        // We can tell this task object that we want to pause our current thread
        // and wait for the client.SendAsync call to finish.
        responseTask.Wait();
    
        // - Once that thread finishes, and the code continues on, we need to 
        //   tell it to read out the response data from the backing objects. 
        // - The responseTask.Result property represents the object the async task 
        //   was wrapping, we want to pull it out, then use it and get the content 
        //   (body of the response) back. 
        // - Getting the response actually creates another async task (the 
        //   .ReadAsStringAsync() call) but by accessing the .Result
        //   property, it is as if we called .ReadAsStringAsync().Wait(); Except that
        //   by using Result directly, we not only call Wait() but we get the resulting, 
        //   wrapped object back. Hope that didn't confuse you much :)
        var queryString = responseTask.Result.Content.ReadAsStringAsync().Result;
    
        // And all your other normal code continues.
        var parts = queryString.Split('&');
        var token = parts[1].Substring(parts[1].IndexOf('=') + 1);
        var secret = parts[0].Substring(parts[0].IndexOf('=') + 1);
        return new OAuthToken(token, secret);
    } 
