    public Task<UserProfileViewModel> GetAsync(Guid id)
    {
        var uri = id.ToString();
        return client.GetAsync(uri).ContinueWith(responseTask =>
        {
            var response = responseTask.Result;
            return response.Content.ReadAsStringAsync().ContinueWith(jsonTask =>
            {
                var json = jsonTask.Result;
                return JsonConvert.DeserializeObject<UserProfileViewModel>(json);
            });
        }).Unwrap();
    }
