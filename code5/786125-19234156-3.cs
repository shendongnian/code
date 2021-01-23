    [HttpGet]
    public JsonResult GetTest()
    {
        var i = YourService.GetSomethingById(1);
        iSerialized = JsonSerializer.Serialize(i);
        return new JsonResult
            {
                ContentEncoding = System.Text.Encoding.UTF8,
                ContentType = "application/json",
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = iSerialized
            };
    }
