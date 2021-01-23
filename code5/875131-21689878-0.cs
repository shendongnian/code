    public ActionResult PricingList()
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
