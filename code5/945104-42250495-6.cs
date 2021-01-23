    [HttpGet]
    public async Task<HttpResponseMessage> Search([FromUri] ArticlesSearchModel searchModel) // the type converter will be applied only to the property of the types marked with our attribute
    {
        // do search
    }
