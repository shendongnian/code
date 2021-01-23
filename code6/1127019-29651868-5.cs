    public ActionResult Customer()
    {
        DetermineCustomerCode();
        DetermineIfCustomerIsEligible();
        return isCustomerEligible ? View() : RedirectToAction("Index");
    } 
