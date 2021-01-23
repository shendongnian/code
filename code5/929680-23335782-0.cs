    [HttpPost]
    public ActionResult Save()
    {
        TempData["message"] = "Save successfully";
        return View("~/Views/Jobs/Message.cshtml");
    }
