    public class InvestmentReturn
    {
        public double ProfitElement { get; set; }
        public double InvestmentProfit{ get; set; }
        public RetailInvestmentReturn(IRetailBusiness bus)
        {
            ProfitElement = bus.GetProfitElement();
        }
        public double CalculateBaseProfit()
        {
            ......
        }
    }
    public class BenzolMedicinePatent : EntityBaseClass, IIntellectualRights
    {
        public double Royalty { get; set; }
        public BenzolMedicinePatent(double royalty)
        {
            Royalty = royalty;
        }
        public override double GetProfitElement() 
        {
            return royalty;
        }    
    }
    public class BookShop : EntityBaseClass, IRetailBusiness
    {
        public double GrossRevenue { get; set; }
        public BookShop(double grossRevenue)
        {
            GrossRevenue = grossRevenue;
        }
        public override double GetProfitElement() 
        {
            return royalty;
        } 
    }
