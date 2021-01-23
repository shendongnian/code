    try
    {
        HttpResponseMessage response = await client.GetStringAsync("http://www.ajshdgasjhdgajdhgasjhdgasjdhgasjdhgas.tk/");
        resp.EnsureSuccessStatusCode();    // Throw if not a success code.
    
        // ...
    }
    catch (HttpRequestException e)
    {
        // Handle exception.
    }
