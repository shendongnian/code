    [ActionName("Check")]
    public async System.Threading.Tasks.Task<bool> CheckPost(HttpRequestMessage request)
    {
        string body = await request.Content.ReadAsStringAsync();
        return true;
    }
