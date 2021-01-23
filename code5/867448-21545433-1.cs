    class Program
    {
        static void Main(string[] args)
        {
            #region MyBusines
            List<IBusiness> allMyProfitableBusiness = new List<IBusiness>();
            BookShop bookShop1 = new BookShop(75);
            AudioCDShop cd1Shop = new AudioCDShop(80);
            EngineDesignPatent enginePatent = new EngineDesignPatent(1200);
            BenzolMedicinePatent medicinePatent = new BenzolMedicinePatent(1450);
            allMyProfitableBusiness.Add(bookShop1);
            allMyProfitableBusiness.Add(cd1Shop);
            allMyProfitableBusiness.Add(enginePatent);
            allMyProfitableBusiness.Add(medicinePatent);
            #endregion
            List<InvestmentReturn> investmentReturns = new List<InvestmentReturn>();
            foreach (IBusiness bus in allMyProfitableBusiness)
            {
                investmentReturns.Add(new InvestmentReturn(bus));
            }
            double totalProfit = 0;
            foreach (var profitelement in investmentReturns)
            {
                totalProfit = totalProfit + profitelement.GetInvestmentProfit();
                Console.WriteLine("Profit: {0:c}", profitelement.GetInvestmentProfit());
            }
            Console.ReadKey();
        }
    }
