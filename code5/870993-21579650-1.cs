    public abstract class InvestmentReturnCalculator
    {
        #region Public
    
        public abstract double ProfitElement { get; }
    
        #endregion
    
        #region Protected
    
        public double GetInvestmentProfit()
        {
            double profit = 0;
            if (ProfitElement < 5)
            {
                profit = ProfitElement * 5 / 100;
            }
            else
            {
                profit = ProfitElement * 10 / 100;
            }
            return profit;
        }
    
        #endregion
    }
    
    public abstract class InvestmentReturnCalculator<T> : InvestmentReturnCalculator where T : IBusiness
    {
        public T BusinessType { get; set; }
    }
    
    public class RetailInvestmentReturnCalculator : InvestmentReturnCalculator<IRetailBusiness>
    {
        public RetailInvestmentReturnCalculator(IRetailBusiness retail)
        {
            BusinessType = retail;
            //Business = new BookShop(100);
        }
    
        public override double ProfitElement {get { return BusinessType.GrossRevenue;}}
    
    }
