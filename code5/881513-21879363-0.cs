    public ActionResult Index()
    {
       DataRerieveClient _proxy = new DataRerieveClient();
       var orderDetails = _proxy.GetProductDetails(null);
       return View(orderDetails);
    }
