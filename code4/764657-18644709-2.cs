    public ActionResult Test()
    {
        ViewData["Message"] = "HELLO THERE";
        return View("DebugView");
    }
