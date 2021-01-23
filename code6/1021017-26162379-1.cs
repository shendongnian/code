    [Route("/api/projectApi/categories")]
    [ResponseType(typeof(IEnumerable<Category>))]
    public async Task<IHttpActionResult> GetCategories(string search, int max)
    { ...
    }
