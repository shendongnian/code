     public static class Helpers
    {
        public static Task<T> ReadAsAsyncCustom<T>(this HttpContent content)
        {
            var formatters = new MediaTypeFormatterCollection();
            formatters.Clear();
            formatters.Add(new JsonMediaTypeFormatter { UseDataContractJsonSerializer = true });
            return content.ReadAsAsync<T>(formatters);
        }
    }
