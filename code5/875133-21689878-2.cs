      public ActionResult PricingList()
          { 
              if(Request.QueryString["choosestate"]!=null)
               {
                   string state=Request.QueryString["choosestate"].ToString();
                   var StateList = repository.GetStateList(state);
                    return View(state);
                }
                else
                {
                  return View();
                 }
                  
    
            }
