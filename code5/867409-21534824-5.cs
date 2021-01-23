    public class RetailInvestmentReturn : InvestmentReturn<IRetailBusiness>
    {
        public RetailInvestmentReturn(IRetailBusiness retail)
        {
            Business = retail;
        }
        public override double GetInvestmentProfit()
        {
            ProfitElement = Business.GrossRevenue;
            return CalculateBaseProfit();
        }
    }
