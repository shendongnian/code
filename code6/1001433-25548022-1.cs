    public ActionResult MyOrderAction()
    {
        //get the model
        OrderModel model = myDataProvider.GetOrderModel();
        return View(model);
    }
