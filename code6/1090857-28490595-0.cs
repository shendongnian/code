    async Task ExecuteUriAsync(string username, string password, Uri uri)
    {
        using (var handler = new HttpClientHandler { Credentials = new NetworkCredential(username, password) })
        {
            using (var client = new HttpClient(handler))
            {
                Stream stream = await client.GetStreamAsync(uri);
                byte[] buffer = new byte[10240];
    
                while(true)
                {
                    int byteCount = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (byteCount == 0)
                    {
                        // end-of-stream...must be done with the connection
                        return;
                    }
                    DoSomethingWithBytes(bytes, byteCount);
                }
            }
        }
    }
