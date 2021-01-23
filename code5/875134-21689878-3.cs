      public ActionResult PricingList()
        {
            string state;
            if (Request.QueryString["choosestate"] != null)
            {
                state = Request.QueryString["choosestate"].ToString();
            }
            else
            {
                state = "ALL";
            }
            var StateList = repository.GetStateList(state);
            return View(StateList);
        }
