    [HttpGet]
    public HttpResponseMessage GetDegreeCodes(int id)
    {
        StringContent sc = new StringContent("Your JSON content from Redis here");
        sc.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                
        HttpResponseMessage resp = new HttpResponseMessage();
        resp.Content = sc;
    
        return resp;
    }
