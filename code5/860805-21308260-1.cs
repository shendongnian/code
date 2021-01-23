    [HttpPost]
    public ActionResult SubmitData(MyClass c)
    {
        var name = Request.Form["MyName"];
        return View();
    }
