    public class RetailInvestmentReturnCalculator : InvestmentReturnCalculator<IRetailBusiness>
    {
        public RetailInvestmentReturnCalculator(IRetailBusiness retail)
        {
            Business = retail;
        }
    
        public override double GetInvestmentProfit()
        {
            ProfitElement = Business.GrossRevenue;
            return CalculateBaseProfit();
        }
    }
    
    public class IntellectualRightsInvestmentReturnCalculator : InvestmentReturnCalculator<IIntellectualRights>
    {
    
        public IntellectualRightsInvestmentReturnCalculator(IIntellectualRights intellectual)
        {
            Business = intellectual;
        }
    
        public override double GetInvestmentProfit()
        {
            ProfitElement = Business.Royalty;
            return base.CalculateBaseProfit();
        }
    }
      
