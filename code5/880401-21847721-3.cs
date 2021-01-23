    public ActionResult Contact()
    {
        var model = BLL.MyModel();
        return View(model);
    }
