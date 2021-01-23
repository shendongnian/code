    foreach (IBusiness bus in allMyProfitableBusiness)
    {
        // No type checking or casting.  It is scalable to new business types.
        investmentReturns.Add(bus.GetReturnInvestment());
    }
    
