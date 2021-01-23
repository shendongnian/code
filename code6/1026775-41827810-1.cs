    // Create a signed URL which allows the requester to PUT data with the text/plain content-type.
    UrlSigner urlSigner = UrlSigner.FromServiceAccountCredential(credential);
    var destination = "places/world.txt";
    string url = urlSigner.Sign(
        bucketName,
        destination,
        TimeSpan.FromHours(1),
        HttpMethod.Put,
        contentHeaders: new Dictionary<string, IEnumerable<string>> {
            { "Content-Type", new[] { "text/plain" } }
        });
    
    // Upload the content into the bucket using the signed URL.
    string source = "world.txt";
    
    ByteArrayContent content;
    using (FileStream stream = File.OpenRead(source))
    {
        byte[] data = new byte[stream.Length];
        stream.Read(data, 0, data.Length);
        content = new ByteArrayContent(data)
        {
            Headers = { ContentType = new MediaTypeHeaderValue("text/plain") }
        };
    }
    
    HttpResponseMessage response = await httpClient.PutAsync(url, content);
