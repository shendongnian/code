    public ActionResult B(MyModel model)
    {
      ...
    var yourObj = TempData["object"];
        model=yourObj .Model;
      return View();
    }
