    public JsonResult ValidateContractor1()
    {
       // gets the name of the property being validated, e.g. "Cntrctr1"
       string fieldName = Request.QueryString.Keys[0];
       // gets the value to validate
       string Cntrctr = Request.QueryString[fieldName];
       // carry on as before
       var valid = Validations.ValidateContractor(Cntrctr);
       if (!valid)
       {return Json("Enter correct contractor", JsonRequestBehavior.AllowGet);}
       else{return Json(true, JsonRequestBehavior.AllowGet);}
    }
