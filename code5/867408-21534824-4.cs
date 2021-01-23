    public abstract class InvestmentReturn
    {
        public double ProfitElement { get; set; }
        public abstract double GetInvestmentProfit();
        public double CalculateBaseProfit()
        {
            // ...
        }
    }
    public abstract class InvestmentReturn<T>: InvestmentReturn where T : IBusiness
    {
        public T Business { get; set; }        
    }
