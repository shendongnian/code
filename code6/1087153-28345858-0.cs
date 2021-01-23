    [Route("First")]
    public ActionResult First()
    {
        return RedirectToAction("Second", new { areaName= "plans"});
    }
    
    [Route("Second/{areaName}")]
    public ActionResult Second(string areaName)
    {
        return new ContentResult() { Content = "Second : " + areaName};
    }
