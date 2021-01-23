    public class BookShop : BusinessBaseClass<RetailInvestment>, IRetailBusiness
    {
        public double GrossRevenue { get; set; }
        public BookShop(double grossRevenue)
        {
            GrossRevenue = grossRevenue;
        }
        // commented because not inheriting from EntityBaseClass directly
        // public InvestmentReturn GetReturn()
        // {
        //     return new RetailInvestmentReturn(this);
        // }
    }
