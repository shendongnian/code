    private double materialsCost;
    protected double MaterialsCost
    {
        get 
        { 
             materialsCost = (this as IAccountable).CalculateSelfCost();
             return materialsCost;
        }
    }
