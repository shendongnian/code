    public ActionResult Index()
    {
      var model = model = new OrderNoLocationViewModel();
      model.Shipper = "Ray";
      return View(model);
    }
