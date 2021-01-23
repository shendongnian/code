     [HttpGet]
            public HttpResponseMessage Get([FromUri]InputFilterModel filter)
            {
                try
                {
                    if (filter == null || ModelState.IsValid == false)
                    {
                       return (filter == null)? Request.CreateErrorResponse(HttpStatusCode.BadRequest,"Input parameter can not be null")
                                              : Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
