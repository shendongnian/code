    public class RetailInvestmentReturn : InvestmentReturn<IRetailBusiness>
    {
       public override double GetInvestmentProfit()
       {
           ProfitElement = Business.GrossRevenue;
           return CalculateBaseProfit();
       }
    }
