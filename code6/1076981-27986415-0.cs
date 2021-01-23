    [HttpPost]
    public ActionResult ValidateCustomer(int? id)
    {
         if(id != null)
              return View("/SomeOtherController/Example");
      
          return View("/Home/Index");
    }
