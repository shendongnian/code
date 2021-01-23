    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(ORDERMetadata model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }
      try
      {
        Order order = new Order();
        // map properties from your view model to the data model
        order.Order_Number = model.Order_Number;
        ... // other properties
        db.ORDERS.Add(order);
        db.SaveChanges();
        return RedirectToAction("Index");
      }                                       
      catch (Exception ex)
      {              
        ViewBag.Error = ex.ToString();
        return View(model);
      }
    }
