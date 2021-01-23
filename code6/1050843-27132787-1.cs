    [HttpPost]
    public ActionResult(UserGoalsStepViewMdoel vm){
          if(ModelState.IsValid){
                 vm.Post();
                 ModelState.Clear(); // if you want to show changed properties in view.
           }
           return View(vm);
    }
