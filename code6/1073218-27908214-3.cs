    public ActionResult Edit(ContractModel entity)
     {
        if(ModelState.IsValid)
        { 
           if(curUser.isInputer) { return RedirectToAction("SomeAction");}
           if(curUser.Authorizer) { return RedirectToAction("OtherAction");}
        }
        if(!ModelState.IsValid)
        {
            entity.FormError = true; // you will need to add this attribute to your model
        }
        return PartialView(entity);
    }
