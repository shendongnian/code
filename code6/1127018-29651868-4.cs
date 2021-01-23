    public ViewResult Customer()
    {
        DetermineCustomerCode();
        DetermineIfCustomerIsEligible();
        return isCustomerEligible ? View() : View("Index");
    } 
