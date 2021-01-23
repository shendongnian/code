    private async Task<MyResponseObject> CallService(Uri url)
    {
        MyResponseObject r = new MyResponseObject();
        try
        {
            HttpResponseMessage response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                // do something with the information successfully received
                r.Data = await response.Content.ReadAsStringAsync();
            }
        }
        catch (Exception ex)
        {
            // do something with the exception
            r.Exception = ex;
        }
        return r;
    }
