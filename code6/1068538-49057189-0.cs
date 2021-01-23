        public static async Task HttpDownloadStreamAsync(this HttpClient httpClient, string url, Stream output)
        {
            using (var httpResponse = await httpClient.GetAsync(url).ConfigureAwait(false))
            {
                // Ensures OK status
                response.EnsureSuccessStatusCode();
                // Get response stream
                var result = await httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false);
                await result.CopyToAsync(output).ConfigureAwait(false);
                output.Seek(0L, SeekOrigin.Begin);                
            }
        }
