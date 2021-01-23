    private async void Foo()
    {
        HttpClient client = new HttpClient();
        // Do not cache response, use HttpCompletionOption.ResponseHeadersRead.
        HttpResponseMessage response = await client.GetAsync(
            "http://localhost/?big=2000000000",
            HttpCompletionOption.ResponseHeadersRead);
        // Consume response as a System.IO.Stream.
        Stream contentStream = await response.Content.ReadAsStreamAsync();
        int bytesRead;
        do
        {
            byte[] buffer = new byte[1000000];
            bytesRead = contentStream.Read(buffer, 0, buffer.Length);
        } while (bytesRead > 0);
    }
