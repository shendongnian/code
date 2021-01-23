    [AcceptVerbs(HttpVerbs.Post)]
    [ValidateAntiForgeryToken]
    public ActionResult ProcessForm(FormCollection form, Model model)
    {
        // code here
        var resultAsString = RenderViewAsString("~/Views/viewpage.aspx", null, ControllerContext, ViewData, TempData);
        return Content(resultAsString, "text/html");
    }
