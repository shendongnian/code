    [AuthorizationFilter]
    public ActionResult Authorized()
    {
        ControllerModel model = new ControllerModel();
        model.Authorized = (bool)HttpContext.Session["authorized"];
        return View(model);
    }
