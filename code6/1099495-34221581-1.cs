    private async Task<string> ReadContentAsString(HttpResponseMessage response)
    {
        // Check whether response is compressed
        if (response.Content.Headers.ContentEncoding.Any(x => x == "gzip")) 
        {
            // Decompress manually
            using (var s = await response.Content.ReadAsStreamAsync())
            {
                using (var decompressed = new GZipStream(s, CompressionMode.Decompress))
                {
                    using (var rdr As New IO.StreamReader(decompressed))
                    {
                        return await rdr.ReadToEndAsync();
                    }
                }
            }
        else
            // Use standard implementation if not compressed
            return await response.Content.ReadAsStringAsync();
    }
