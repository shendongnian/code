    private HttpClient _client;
    private void InitClient()
    {
        _client = new HttpClient();
        // Configure the client as needed with CookieContainer, Credentials, etc
        // ...
    }
    private async Task StartVideoStreamingAsync(Uri uri)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, uri);
        // Add required headers
        // ...
        
        var response = await _client.SendAsync(request);
        ulong length = (ulong)response.Content.Headers.ContentLength;
        string mimeType = response.Content.Headers.ContentType.MediaType;
        Stream responseStream = await response.Content.ReadAsStreamAsync();
        
        // Delegate that will fetch a stream for the specified range
        AsyncRangeDownloader downloader = async (start, end) =>
            {
                var request2 = new HttpRequestMessage();
                request2.Headers.Range = new RangeHeaderValue((long?)start, (long?)end);
                // Add other required headers
                // ...
                var response2 = await _client.SendAsync(request2);
                return await response2.Content.ReadAsStreamAsync();
            };
        var videoStream = new StreamingRandomAccessStream(responseStream, downloader, length);
        _mediaElement.SetSource(videoStream, mimeType);
    }
    
