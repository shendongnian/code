    public async Task<HttpResponseMessage> Get(string acctNumber, string stmtDate)
    {
        HttpResponseMessage response2 = new HttpResponseMessage();
    
        HttpClient client= new HttpClient();
        string url = "http://localhost:9090/BusinessLayer?acctNumber=" + acctNumber + "&stmtDate=" + stmtDate;
        // NOTE 1: here we are only reading the response1's headers and not the body. The body of response1 would be later be 
        // read by response2.
        HttpResponseMessage response1 = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
    
        // NOTE 2: here we need not close response1's stream as Web API would close it when disposing
        // response2's stream content.
        response2.Content = new StreamContent(await response1.Content.ReadAsStreamAsync());
        response2.Content.Headers.ContentLength = response1.Content.Headers.ContentLength;
        response2.Content.Headers.ContentType = response1.Content.Headers.ContentType;
    
        return response2;
    }
