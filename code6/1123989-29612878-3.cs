    [ResponseType(typeof(List<Item>))]
    public IHttpActionResult Post()
    {
        var items = new List<Item>();
        // Do something to fill items here...
        HttpContext.Current.Response.AddHeader("Item-Count", items.Count.ToString());
        return Content(HttpStatusCode.Created, items);
    }
