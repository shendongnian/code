    using (var client = new HttpClient())
    {
        var resp = await client.PostAsJsonAsync("http://your host/Login.aspx/Login", 
                                                 new { username = "", password = "" });
        var str = await resp.Content.ReadAsStringAsync();
    }
