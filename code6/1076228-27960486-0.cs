    public virtual ActionResult Index(string Id) 
    {
        var input = new CustomInput();
        input.PaymentTypeId = Id;
        TempData["TheCustomData"] = input; //temp data, this only sticks around for one "postback"
        return RedirectToAction(MVC.Ops.SPS.Actions.Test());
    }
    
    public virtual ActionResult Test()
    {
            CustomInput = TempData["TheCustomData"] as CustomInput;
            //now do what you want with Custom Input
             return View();
    
    }
