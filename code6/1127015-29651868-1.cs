    public ViewResult Customer()
    {
        DetermineCustomerCode();
        DetermineIfCustomerIsEligible();
        return isCustomerEligible ? View() : RedirectToAction("Index");
    } 
