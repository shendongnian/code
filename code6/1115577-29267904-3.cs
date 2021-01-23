    public ActionResult Edit(OrderViewModel model)
    {
      ModelState.Clear(); // clear all model state
      model.Step = model.Step + 1;
      return View();
    }
