    [HttpPost]
    public ActionResult Index(User model)
    {
        if(ModelState.IsValid){
            return RedirectToAction("Register");
        }  
        else{
            return view(model);
        }
    }
