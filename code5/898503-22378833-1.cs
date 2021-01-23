    [HttpPost]
    private async Task<string> PostTo3D() 
    {
        HttpClient client = new HttpClient();
        var content = new StringContent("=Here is my input string");
        content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
        client.PostAsync("https://<sunucu_adresi>/<3dgate_path>", content)
            .ContinueWith(task =>
            {
    
                var response = task.Result;
                return response;
            });
    }
