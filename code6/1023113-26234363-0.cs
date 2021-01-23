    public async Task<HttpResponseMessage> Get(long id)
    {
        var distribution = await this.Service.GetByIdAsync(id);
        var result = distribution == null ?
                Request.CreateResponse(HttpStatusCode.NotFound) :
                Request.CreateResponse(
                        HttpStatusCode.OK, 
                        distribution.AsViewModel(identity));
        return result;
    }
