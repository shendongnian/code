    public ActionResult Test()
    {
         ViewBag.EnumList = PaymentType.Self.ToSelectList();
    
         return View();
    }
