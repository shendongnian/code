    public ActionResult Whatever()
    {
        string url = //...
        Request.RequestContext.HttpContext.Server.TransferRequest(url);
        return Content("success");//Doesn't actually get returned
    }
