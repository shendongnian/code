    public async override Task<T> ExecuteAsync()
    {
        var url = BuildUrl();
        var httpClient = new HttpClient();
        try
        {
            var response = await httpClient.GetAsync(url);
            return await HandleResponseAsync(response);
        }
        catch (HttpRequestException hex)
        {
            return (T)Response.CreateErrorResponse(); // compiles on liqpad
        }
    }
