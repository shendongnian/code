     public ViewResult Index()
        {
           return View();
        }
        
        public ViewResult Customer()
        {
            DetermineCustomerCode();
            DetermineIfCustomerIsEligible();
            return isCustomerEligible ? View() : View("Index");
        }
