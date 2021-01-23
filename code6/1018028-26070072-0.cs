    public static async Task<string> GetVersion(int port, string method)
    {
        try
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:" + port);
                if (method.ToUpper().Equals("GETSTR"))
                {
                    return await client.GetStringAsync("/API/Version");
                }
                else if (method.ToUpper().Equals("GET"))
                {
                    var res = await client.GetAsync("/API/Version");
                    return await res.Content.ReadAsStringAsync();
                }
                else if (method.ToUpper().Equals("POST"))
                {
                    var content = new FormUrlEncodedContent(new[] 
                    {
                        new KeyValuePair<string, string>("name", "jax")
                    });
                    var res = await client.PostAsync("/API/Version", content);
                    return await res.Content.ReadAsStringAsync();
                }
            }
        }
        catch (Exception ex)
        {
            return "Error: " + ex.Message;
        }
    }
