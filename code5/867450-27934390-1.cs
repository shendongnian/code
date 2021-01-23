    class Program
    {
        static void Main(string[] args)
        {
            List<Business> allMyProfitableBusiness = new List<Business>();
            BookShop bookShop1 = new BookShop(75);
            AudioCDShop cd1Shop = new AudioCDShop(80);
            EngineDesignPatent enginePatent = new EngineDesignPatent(1200);
            BenzolMedicinePatent medicinePatent = new BenzolMedicinePatent(1450);
            allMyProfitableBusiness.Add(bookShop1);
            allMyProfitableBusiness.Add(cd1Shop);
            allMyProfitableBusiness.Add(enginePatent);
            allMyProfitableBusiness.Add(medicinePatent);
            double totalProfit = 0;
            foreach (var business in allMyProfitableBusiness)
            {
                totalProfit = totalProfit + business.GetInvestmentProfit();
                Console.WriteLine("Profit: {0:c}", business.GetInvestmentProfit());
            }
            Console.ReadKey();
        }
    }
    public abstract class Business
    {
        public abstract double Profit { get; }
        public double GetInvestmentProfit()
        {
            double profit = 0;
            if (Profit < 5)
            {
                profit = Profit * 5 / 100;
            }
            else if (Profit < 20)
            {
                profit = Profit * 7 / 100;
            }
            else
            {
                profit = Profit * 10 / 100;
            }
            return profit;
        }
    }
    public abstract class RetailBusiness : Business
    {
        public double GrossRevenue { get; set; }
        public override double Profit {get {return GrossRevenue; } }
    }
    public abstract class IntellectualRights : Business
    {
        public double Royalty { get; set; }
        public override double Profit {get {return Royalty; } }
    }
    #region Intellectuals
    public class EngineDesignPatent : IntellectualRights
    {
        public EngineDesignPatent(double royalty)
        {
            Royalty = royalty;
        }
    }
    public class BenzolMedicinePatent : IntellectualRights
    {
        public BenzolMedicinePatent(double royalty)
        {
            Royalty = royalty;
        }
    }
    #endregion
    #region Retails
    public class BookShop : RetailBusiness
    {
        public BookShop(double grossRevenue)
        {
            GrossRevenue = grossRevenue;
        }
    }
    public class AudioCDShop : RetailBusiness
    {
        public AudioCDShop(double grossRevenue)
        {
            GrossRevenue = grossRevenue;
        }
    }
    #endregion
