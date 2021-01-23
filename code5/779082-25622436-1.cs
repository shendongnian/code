    try
    {
        HttpResponseMessage response = await client.GetAsync("http://www.ajshdgasjhdgajdhgasjhdgasjdhgasjdhgas.tk/");
        response.EnsureSuccessStatusCode();    // Throw if not a success code.
    
        // ...
    }
    catch (HttpRequestException e)
    {
        // Handle exception.
    }
