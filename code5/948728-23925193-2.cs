    public ActionResult MyProduceAction()
    {
      DAL dal = new DAL();
      var ProductList = dal.GetAllProductList();
      ViewBag.ProductList = ProductList;
      return View();
    }
