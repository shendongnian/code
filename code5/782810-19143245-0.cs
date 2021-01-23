    [HttpParamAction]
    [HttpPost]
    public ActionResult Find(int Id)
    {
        var model = GetDisplay().TakeWhile(m => m.familyId == Id);
        return View("Index", model);
    }
