    public static async Task<String> getResponse(String url)
    {
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage request = await httpClient.GetAsync(url).ConfigureAwait(false);
        String stream = await request.Content.ReadAsStringAsync().ConfigureAwait(false);
        return stream;
    }
