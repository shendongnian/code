    [Route("api/my")]
    public HttpResponseMessage GetAll() {
        // ...
    }
    
    [Route("api/my/{id:regex(^[^,]+$)}")]
    public HttpResponseMessage GetSingle(string id)
    {
        // ...
    }
    
    [Route("api/my/{ids:regex(,)}")]
    public HttpResponseMessage GetMultiple(string ids)
    {
        // strings
        var idList = ids.Split(',');
        //// ints
        // var idList = ids.Split(',').Select(i => Convert.ToInt32(i)).ToList();
    
        // ...
    }
