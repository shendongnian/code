    if(ModelState.Values.Count()>0) {
         var errors = ModelState.Values.SelectMany(v => v.Errors);
         
    } else {
         if (ModelState.IsValid)
         {
             cus.CusModelData.Add(cusmodel);
             cus.SaveChanges();
             return RedirectToAction("ShowSuccess", "Home");
         }
         return View();
    }
