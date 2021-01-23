    public HttpResponseMessage Get(string id, string securityToken)
    {
        var forbidden = true;
        if (forbidden)
        {
            return this.Request.CreateResponse(HttpStatusCode.Forbidden);
        }
        return Ok(userRepository.LoadAll());
    }
