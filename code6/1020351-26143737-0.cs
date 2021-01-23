    Public ActionResult Edit (int? id)
    {
       if (Product.Id.Equals(id))
       {
         RedirectToAction("Add");
       }
    }
