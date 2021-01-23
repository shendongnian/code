    public ActionResult Index()
    {
        return View(new BuyBitcoinViewModel());
    }
    [HttpPost]
    public ActionResult Index(BuyBitcoinViewModel model)
    {
        //
        return View("Index");
    }
