    if (ModelState.IsValid)
    {
      ....
    }
    ViewBag.Postes = // set the value here before returning the view
    return View(model);
