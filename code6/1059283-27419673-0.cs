    [Route("api/webapisearchreults")]
    [HttpGet]
    public HttpResponseMessage Get([FromUri]string searchQuery)
    {
       var data = SearchLogic.Instance.GetArticleSearchResults(searchQuery);
       var response = Request.CreateResponse(HttpStatusCode.OK, data);
       return response;
     }
