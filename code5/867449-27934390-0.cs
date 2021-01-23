    class Program2
    {
        static void Main(string[] args)
        {
            List<Business> allMyProfitableBusiness = new List<Business>();
            Business bookShop1 = new Business(75);
            Business cd1Shop = new Business(80);
            Business enginePatent = new Business(1200);
            Business medicinePatent = new Business(1450);
            allMyProfitableBusiness.Add(bookShop1);
            allMyProfitableBusiness.Add(cd1Shop);
            allMyProfitableBusiness.Add(enginePatent);
            allMyProfitableBusiness.Add(medicinePatent);
            foreach (var business in allMyProfitableBusiness)
            {
                Console.WriteLine("Profit: {0:c}", business.GetInvestmentProfit());
            }
            Console.ReadKey();
        }
    }
    public class Business
    {
        private double ProfitElement;
        public Business(double profitElement)
        {
            ProfitElement = profitElement;
        }
        public double GetInvestmentProfit()
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
