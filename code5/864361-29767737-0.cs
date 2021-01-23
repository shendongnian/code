    [HttpGet]
    public IHttpActionResult GetProduct(int id)
    {
        System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
        string token = string.Empty;
        string pwd = string.Empty;
        if (headers.Contains("username"))
        {
            token = headers.GetValues("username").First();
        }
        if (headers.Contains("password"))
        {
            pwd = headers.GetValues("password").First();
        }
        //code to authenticate and return some thing
        if (!Authenticated(token, pwd)
            return Unauthorized();
        var product = products.FirstOrDefault((p) => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }
