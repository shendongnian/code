    private static async Task<T> ParseResponseMessageToObject<T>(HttpResponseMessage responseMessage)
    {
        if (!responseMessage.IsSuccessStatusCode) { return default(T); }
        using (Stream responseStream = await responseMessage.Content.ReadAsStreamAsync())
        {
            return JsonConvert.DeserializeObject<T>(new StreamReader(responseStream).ReadToEnd());
        }
    }
