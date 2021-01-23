     [HttpPost]
    public ActionResult Submit(HomeLoanViewModel vm)
    {
         if (ModelState.IsValid){
                   vm.Post();
                   return View(vm);
         }
      return View(vm);
    }
