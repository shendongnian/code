    private HttpClient client;
    public async Task<CommentsObject> GetComments()
    {
        client = new HttpClient();
        var response = await client.GetAsync("http://www.reddit.com/r/AskReddit/comments/1ut6xc.json");
        if (response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync();
            var comments = await JsonConvert.DeserializeObjectAsync<CommentsObject>(json);
            return comments;
        }
        else
        {
            throw new Exception("Errorhandling message");
        }
    }
