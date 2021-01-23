    public abstract class InvestmentReturnCalculator
    {
        public double ProfitElement { get; set; }
        public abstract double GetInvestmentProfit();
    
        protected double CalculateBaseProfit()
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
    }
    
    public abstract class InvestmentReturnCalculator<T> : InvestmentReturnCalculator where T : IBusiness
    {
        public T BusinessType { get; set; }
    }
    
