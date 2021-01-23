    public ActionResult MyOrderAction()
    {
        //get the XML
        XElement xmlData = ReadTheXmlData();
        //get the model
        OrderModel model = new OrderModel(xmlData);
        return View(model);
    }
