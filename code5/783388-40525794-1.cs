    public static async Task<HttpResponseMessage> PostAsJsonAsync<TModel>(this HttpClient client, string requestUrl, TModel model)
    {
        var serializer = new JavaScriptSerializer();
        var json = serializer.Serialize(model);
        var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
        return await client.PostAsync(requestUrl, stringContent);
    }
