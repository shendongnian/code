    [HttpPost]
    public ActionResult PostViaAjax()
    {
        var body = Request.BinaryRead(Request.TotalBytes);
        var result = Content(JsonError(new Dictionary<string, string>()
        {
            {"err", "Some error!"}
        }), "application/json; charset=utf-8");
        HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return result;
    }
