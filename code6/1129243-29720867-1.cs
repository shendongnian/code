    public async Task Start()
    {
        //Twitter Streaming API
        string stream_url = "https://stream.twitter.com/1.1/statuses/filter.json";
    
        string trackKeywords = "twitter";
        string followUserId = "";
        string locationCoord = "";
    
        string postparameters = (trackKeywords.Length == 0 ? string.Empty : "&track=" + trackKeywords) +
                                (followUserId.Length == 0 ? string.Empty : "&follow=" + followUserId) +
                                (locationCoord.Length == 0 ? string.Empty : "&locations=" + locationCoord);
    
        if (!string.IsNullOrEmpty(postparameters))
        {
            if (postparameters.IndexOf('&') == 0)
                postparameters = postparameters.Remove(0, 1).Replace("#", "%23");
        }
    
        //Connect
        webRequest = (HttpWebRequest) WebRequest.Create(stream_url);
        webRequest.Timeout = -1;
        webRequest.Headers.Add("Authorization", GetAuthHeader(stream_url + "?" + postparameters));
    
        Encoding encode = Encoding.GetEncoding("utf-8");
        if (postparameters.Length > 0)
        {
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
    
            byte[] _twitterTrack = encode.GetBytes(postparameters);
    
            webRequest.ContentLength = _twitterTrack.Length;
            var _twitterPost = await webRequest.GetRequestStreamAsync();
            await _twitterPost.WriteAsync(_twitterTrack, 0, _twitterTrack.Length);
            _twitterPost.Close();
        }
    
        using (var response = await webRequest.GetResponseAsync())
        {
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                while (!reader.EndOfStream)
                {
                    // Deserialize the JSON obj to type Tweet
                    var jsonObj = JsonConvert.DeserializeObject<Tweet>(await reader.ReadLineAsync(), new JsonSerializerSettings());
    
                    Console.WriteLine(jsonObj.Text);
                    Raise(TweetReceivedEvent, new TweetReceivedEventArgs(jsonObj));
                }
            }
        }
    }
