    public abstract class InvestmentReturnElement
    {
        protected InvestmentReturnElement(IBusiness business)
        {
            this.Business = business;
        }
        public IBusiness Business { get; private set; }
        public abstract double GetInvestmentProfit();
    }
    public class RetailProfit : InvestmentReturnElement
    {
        public RetailProfit(IRetailBusiness retailBusiness)
            : base(retailBusiness)
        {
        }
        public override double GetInvestmentProfit()
        {
            return ((IRetailBusiness)this.Business).Revenue * 5 / 100;
        }
    }
    public class IntellectualRightsProfit : InvestmentReturnElement
    {
        public IntellectualRightsProfit(IIntellectualRights intellectualRightsBusiness)
            : base(intellectualRightsBusiness)
        {
        }
        public override double GetInvestmentProfit()
        {
            return ((IIntellectualRights)this.Business).Royalty * 10 / 100;
        }
    }
