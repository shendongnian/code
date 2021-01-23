    HttpContent content = await new FormUrlEncodedContent(postData)
                                    .WithFinalAmpersandAsync();
    ...
    static class HttpContentExtensions
    {
        public static async Task<HttpContent> WithFinalAmpersandAsync(
            this FormUrlEncodedContent formUrlEncodedContent)
        {
            string content = await formUrlEncodedContent.ReadAsStringAsync();
            return new StringContent(content + "&");
        }
    }
