    public class EngineDesignPatent : EntityBaseClass, IIntellectualRights
    {
        public double Royalty { get; set; }
        public EngineDesignPatent(double royalty)
        {
            Royalty = royalty;
        }
        public InvestmentReturnCalculator GetMyInvestmentReturnCalculator()
        {
            return new IntellectualRightsInvestmentReturnCalculator(this);
        }
    }
    public class BookShop : EntityBaseClass, IRetailBusiness
    {
        public double GrossRevenue { get; set; }
        public BookShop(double grossRevenue)
        {
            GrossRevenue = grossRevenue;
        }
        public InvestmentReturnCalculator GetMyInvestmentReturnCalculator()
        {
            return new RetailInvestmentReturnCalculator(this);
        }
    }
    public class AudioCDShop : EntityBaseClass, IRetailBusiness
    {
        public double GrossRevenue { get; set; }
        public AudioCDShop(double grossRevenue)
        {
            GrossRevenue = grossRevenue;
        }
        public InvestmentReturnCalculator GetMyInvestmentReturnCalculator()
        {
            return new RetailInvestmentReturnCalculator(this);
        }
    }
