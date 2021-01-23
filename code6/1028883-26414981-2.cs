    [HttpPost]
    public ActionResult Index(OrderNoLocationViewModel model)
    {
      ModelState.Clear();
      model.Shipper = "Some other value";
      return View(model);
    }
