    public ActionResult A(MyModel model)
    {
      ...
      TempData["object"] = new { Model= model };
      return RedirectToAction("B");
    }
