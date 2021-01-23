        static void Main(string[] args)
        {
            var allMyProfitableBusiness = new List<IBusiness>();
            // ...
            var investmentReturns = allMyProfitableBusiness.Select(bus => bus.GetReturn()).ToList();
            // ...
        }
