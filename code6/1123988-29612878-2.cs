    [ResponseType(typeof(Item))]
    public IHttpActionResult Post()
    {
        var item = new Item();
        HttpContext.Current.Response.AddHeader("Header-Name", "Header Value");
        return Content(HttpStatusCode.Created, item);
    }
