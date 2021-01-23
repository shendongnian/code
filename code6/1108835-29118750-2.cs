    [HttpPost]
    public HttpResponseMessage Action_Method_Name([FromBody] ClassName obj)
    {
        var objUpdated = new Dal_Provider
        {
            ProviderID = obj.ProviderID,
            ZipCode = obj.ZipCode
        };
        var re = objUpdated.Post();
        return Request.CreateResponse(HttpStatusCode.OK, new { ErrorMessage = re });
    }
