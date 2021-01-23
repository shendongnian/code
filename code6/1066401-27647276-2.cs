    public ActionResult MethodReportingError()
    {
      TempData["Error"] = "Bad things happened";
      return new RedirectResult(Url.Action("ErrorPage", "Home"));
    }
    public ActionResult ErrorPage()
    {
        return View(TempData["Error"]);
    }
