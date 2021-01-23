    public class RetailInvestmentReturn : InvestmentReturn<IRetailBusiness>
    {
        // this will cause a compilation failure; see **EDIT** below
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
