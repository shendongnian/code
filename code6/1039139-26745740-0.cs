    private async Task<object> CallAPI(Uri baseAddress, string requestUri, Type apiType)
    {
        using (var client = new HttpClient()) 
        {
            ....
            if (response.IsSuccessStatusCode)   
            {
                object result = await response.Content.ReadAsAsync(apiType);
            }
        }
    
        ....
    
        return result;
    }
