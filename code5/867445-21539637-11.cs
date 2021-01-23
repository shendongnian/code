    public class RetailInvestmentReturn : InvestmentReturn
    {
        public RetailInvestmentReturn(IRetailBusiness retail)
            : base(retail)
        {
        }
        /* Don't need anymore
        public override  double GetInvestmentProfit()
        {
            //GrossRevenue is the ProfitElement for RetailBusiness
            ProfitElement = Business.GetProfit();
            return base.CalculateBaseProfit();
        } */
    }
    
    public class IntellectualRightsInvestmentReturn : InvestmentReturn
    {
    
        public IntellectualRightsInvestmentReturn(IIntellectualRights intellectual)
            : base(intellectual)
        {
        }
    
        /* Don't need anymore
        public override double GetInvestmentProfit()
        {
            //Royalty is the ProfitElement for IntellectualRights Business
            ProfitElement = Business.GetProfit();
            return base.CalculateBaseProfit();
        } */
    }
