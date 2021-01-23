    public class BookShop : EntityBaseClass, IRetailBusiness
    {
        public double GrossRevenue { get; set; }
        public BookShop(double grossRevenue)
        {
            GrossRevenue = grossRevenue;
        }
        public InvestmentReturn GetReturn()
        {
            return new RetailInvestmentReturn(this);
        }
    }
