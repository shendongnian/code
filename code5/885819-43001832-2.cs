    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult AgreementTerms(AgreementTermViewModel aterms)
    {
         if (ModelState.IsValid)
              return PartialView("_PreRegistration");
         return PartialView("_AgreementTerms", aterms);
    }
