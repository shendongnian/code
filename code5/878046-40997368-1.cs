    [HttpPost]
    public ActionResult Index(Customer c)
    {
      if(ModelState.IsValid)
      {
        var validator= new CustomerValidator();
        var valResult = validator.Validate(c);
        
        if (valResult.Errors.Count != 0)
        {
           valResult.Errors.ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
           return View(vm);
        }
    
        //Your code here
      }
    }
