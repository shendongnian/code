    public override decimal CalculateCost()
    {
        decimal totalCost;
        if (fruitOption)
        {
            totalCost = base.CalculateCost(); 
            return totalCost + (totalCost * .05M);
        }
        else 
        {
            totalCost = base.CalculateCost() ; 
            return totalCost;
        }
    }
