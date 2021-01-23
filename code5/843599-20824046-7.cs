    if (!response.IsSuccessStatusCode)
    {
        throw new ApiException    
        {
            StatusCode = response.StatusCode,
            Reason = response.ReasonPhrase,
            ResponseBody = response.Content.ReadAsStringAync().Result,
        };
    }
