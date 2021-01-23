      public ActionResult PricingList()
          { 
              if(Request.QueryString["choosestate"]!=null)
               {
               string state=Request.QueryString["choosestate"].ToString();
                if (state == null)
                {
                    return View();
                }
                else
                {
                    var StateList = repository.GetStateList(state);
                    return View(state);
                }
                   }
                    return View();
    
            }
