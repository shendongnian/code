    public void PostJSON()
    {
        client = new WebClient();
        client.Headers[HttpRequestHeader.Accept] = "application/json";
        client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.UploadStringCompleted += (object source, UploadStringCompletedEventArgs e) =>
            {
                if (e.Error != null || e.Cancelled)
                {
                    // Error or cancelled
                }
            };
            client.UploadStringAsync(url, message);  // message is the json content in string
    }
