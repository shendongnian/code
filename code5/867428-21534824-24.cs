    public class RetailInvestmentReturn : InvestmentReturn<IRetailBusiness>
    {
        // this won't compile; see **Variation** below for resolution to this problem...
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
