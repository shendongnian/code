    public class RetailInvestmentReturnCalculator : InvestmentReturnCalculator<IRetailBusiness>
    {
        public RetailInvestmentReturnCalculator(IRetailBusiness retail)
        {
            BusinessType = retail;
            //Business = new BookShop(100);
        }
        public override double GetInvestmentProfit()
        {
            ProfitElement = BusinessType.GrossRevenue;
            return CalculateBaseProfit();
        }
    }
    public class IntellectualRightsInvestmentReturnCalculator : InvestmentReturnCalculator<IIntellectualRights>
    {
        public IntellectualRightsInvestmentReturnCalculator(IIntellectualRights intellectual)
        {
            BusinessType = intellectual;
        }
        public override double GetInvestmentProfit()
        {
            ProfitElement = BusinessType.Royalty;
            return base.CalculateBaseProfit();
        }
    }
