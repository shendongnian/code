    HttpResponseMessage myResponse;
    using (var client = new HttpClient())
    using(var backendResponse = await client.GetAsync("http://api.duckduckgo.com/?q=DuckDuckGo&format=json"))
    {
        ValidateResponseStream(await backendResponse.Content.ReadAsStreamAsync());
        myResponse = new HttpResponseMessage(HttpStatusCode.OK);
        myResponse.Content = backendResponse.Content;
    }
    return myResponse;
