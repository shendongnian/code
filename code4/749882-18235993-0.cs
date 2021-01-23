    [HttpPost]
        public void SubmitTimesheet(BillingCodeList model)
        {
    
            string uri = "";
    
            foreach (var billingCode in model.BillingCodes)
            {
               //do stuff with each of these
            }
        }
