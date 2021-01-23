    [HttpGet]
    public HttpResponseMessage GetCategories()
    {
        var categories = GetCategoriesUsingAboveCode();
        return Request.CreateResponse(HttpStatusCode.OK, categories);
    }
