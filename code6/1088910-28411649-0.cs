    [Authorize]
    [HttpGet]
    public FileResult GlobalOverview()
    {
        HttpResponseMessage file = new HttpResponseMessage();
        using (HttpClient httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(this.UserName + ':' + this.Password)));
            Task<HttpResponseMessage> response = httpClient.GetAsync("api.someDomain/Reporting/GlobalOverview");
            file = response.Result;
        }
        return File(file.Content.ReadAsByteArrayAsync().Result, "application/octet-stream", "GlobalOverview.csv");
    }
