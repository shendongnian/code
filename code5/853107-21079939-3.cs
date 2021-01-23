    [System.Web.Http.AllowAnonymous]
    public HttpResponseMessage Options()
    {
        return new HttpResponseMessage(HttpStatusCode.OK);
    }
