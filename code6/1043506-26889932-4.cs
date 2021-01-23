    private static async Task CallService(System.Uri uri)
    {
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Host = uri.Host;
            client.Timeout = System.TimeSpan.FromSeconds(30);
            HttpContent content = new StringContent("", Encoding.UTF8, "application/xml");
    
            var resp = await client.PostAsync(uri, content);// Await it
            resp.EnsureSuccessStatusCode();
            responseString = resp.StatusCode.ToString();
            resp.Dispose();
    
            client.CancelPendingRequests();
        }
    }
