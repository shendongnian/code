    [HttpPost]
    public HttpResponseMessage AddFoo(Foo model)
    {
        try
        {
            //validate
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.OK, new { Status = "error", Message = "Error in foo"});
            //save foo
            var db = new FooBarDB();
            var id = db.AddFoo(model);
            //return new fooId
            return Request.CreateResponse(HttpStatusCode.OK, new { Status = "success", Id = id });
        }
        catch (Exception ex)
        {                
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
        }
    }
    [HttpPost]
    public HttpResponseMessage AddBars(List<Bar> bars)
    {
        try
        {
            //validate bars
            if (!this.ValidateBars(bars))
                return Request.CreateResponse(HttpStatusCode.OK, new { Status = "error", Message = "Errors in bars"});
            //save bars
            var db = new FooBarDB();
            db.AddBars(bars);
            //show success
            return Request.CreateResponse(HttpStatusCode.OK, new { Status = "success"});
        }
        catch (Exception ex)
        {
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
        }
    }
    
    private bool ValidateBars(List<Bar> bars)
    {
        //logic to validate bars
    }
