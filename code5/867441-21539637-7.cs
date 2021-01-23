    public abstract class InvestmentReturn
    {
        protected InvestmentReturn(IBusiness business)
        {
            this.Business = business;
        }
        public double ProfitElement { get; set; }
        public IBusiness Business{ get;  set; }
    
        public override double GetInvestmentProfit()
        {
            ProfitElement = this.Business.GetProfit();
            return base.CalculateBaseProfit();
        }
    
        public double CalculateBaseProfit()
        {
           double profit = 0;
    
           if (ProfitElement < 5)
           {
               profit = ProfitElement * 5 / 100;
           }
           else if (ProfitElement < 20)
           {
               profit = ProfitElement * 7 / 100;
           }
           else
           {
               profit = ProfitElement * 10 / 100;
           }
    
           return profit;
        }
    }
