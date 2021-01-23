    private static async Task<T> ParseResponseMessageToObject<T>(HttpResponseMessage responseMessage) where T : class, new()
        {
            if (!responseMessage.IsSuccessStatusCode) { return null; }
            using (Stream responseStream = await responseMessage.Content.ReadAsStreamAsync())
            {
                return (T)JsonConvert.DeserializeObject(new StreamReader(responseStream).ReadToEnd(), typeof(T));
            }
        }
