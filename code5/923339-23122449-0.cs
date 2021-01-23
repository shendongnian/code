        Task<string> stuff = CallApiAsync(); 
        return await stuff;
    }
    private async Task<string> CallApiasync()
    {
        using (var httpClient = new HttpClient())
        {
            string response = await httpClient.GetStringAsync(Util.EndPoint).ConfigureAwait(false); 
            return response;
        }
    }
