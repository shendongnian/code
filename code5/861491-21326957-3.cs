    async Task<HttpWebResponse> GetResponseWithRetryAsync(string url, int retries)
    {
        if (retries < 0)
            throw new ArgumentOutOfRangeException();
    
        var request = WebRequest.Create(url);
        while (true)
        {
            try
            {
                var result = await request.GetResponseAsync();
                return (HttpWebResponse)result;
            }
            catch (Exception ex)
            {
                if (--retries == 0)
                    throw; // rethrow last error
                // otherwise, log the error and retry
                Debug.Print("Retrying after error: " + ex.Message);
            }
        }
    }
