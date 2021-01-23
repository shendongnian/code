    public async Task<ValidatePhoneNumberResult> ValidatePhoneNumberAsync(object dto)
    {
        Uri uri = new Uri(MY_URI);
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri);
    
        request.Content = new FormUrlEncodedContent(dto.ToDictionary());
        return await GetResult<ValidatePhoneNumberResult>(request);
    }
