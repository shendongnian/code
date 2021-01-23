    // POST: /SubnetSettings/Edit1/5   
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit1([Bind(Include = "Id,Name,fDialUp,fPulse,fUseExternalGSMModem,fGsmDialUp,bUploadMethodId")] SubnetSettings subnetsettings)
    {
        if (ModelState.IsValid)
            {
                //Retrieve from base by id
                SubnetSettings objFromBase = templateDb2.GetById(subnetsettings.Id);
                //This will put all attributes of subnetsettings in objFromBase
                FunctionConsist(objFromBase, subnetsettings)
                templateDb2.Save(objFromBase);   
                //templateDb2.Save(subnetsettings);   
                return RedirectToAction("Index");
            }
        return View(subnetsettings);
    }
