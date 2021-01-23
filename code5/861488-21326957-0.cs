    async Task<HttpWebResponse> GetResponseAsync(string url, int retries)
    {
        if ( retries < 0)
            throw new ArgumentOutOfRangeException();
    
        var request = WebRequest.Create(url);
        while (true)
        {
            try
            {
                return (HttpWebResponse)await request.GetResponseAsync();
            }
            catch (Exception ex)
            {
                // log error
                Console.WriteLine("Retrying after error: " + ex.Message);
                if (--retries == 0)
                    throw; // rethrow last error
                // otherwise retry
            }
        }
    }
