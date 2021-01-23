    public class Article
    {
        private static readonly Dictionary<Pricemethod, Func<IEnumerable<double>, double>>
            priceMethods = new Dictionary<Pricemethod, Func<IEnumerable<double>, double>>
            {
                {Pricemethod.Max,ph => ph.Max()},
                {Pricemethod.Min,ph => ph.Min()},
                {Pricemethod.Average,ph => ph.Average()},
            };
    
        public Pricemethod Pricemethod { get; set; }
        public List<Double> Pricehistory { get; set; }
    
        public double Price
        {
            get
            {
                return priceMethods[Pricemethod](Pricehistory);
            }
        }
    }
