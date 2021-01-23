    [Route("getExcel")]
    [HttpPost]
    public HttpResponseMessage getExcel(FormDataCollection data)
    {
       string[] ids = data.GetValues("ids");
       ...
    }
