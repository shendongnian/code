    Task<string> result = GetExternalIP();    
    string externalIP = (new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}"))
                            .Matches(result.Result)[0].ToString();
    ......
    public async Task<string> GetExternalIP()
    {
       HttpClient http = new System.Net.Http.HttpClient();
       HttpResponseMessage response = await http.GetAsync("http://www.realip.info/api/p/realip.php");
       return await response.Content.ReadAsStringAsync();
    }
