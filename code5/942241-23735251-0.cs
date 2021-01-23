    [HttpPost]
    public ActionResult SingleSSOMPLogin(SSoStateModel model)
    {
        //Check the Code with SP providers and Authorization server.
          if(model.SAMLAssertion.validMPData)
          {
            return RedirectToAction("SSOServiceMP" , "SAML");
          }else
          { 
             //Error message processed.
             ModelState.AddModelError("error", SSOState.SAMLAssertion.errorMessage);             
             return View(model);
          }
    }
    
