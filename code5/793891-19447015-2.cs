    public class Milk : IBeverage
    {
        private readonly IBeverage _beverage;
        public Milk(IBeverage beverage)
        {
            _beverage = beverage;
        }
        public decimal Price
        {
            get { return _beverage.Price; } // price not changed
        }
        public string Description
        {
            get { return _beverage.Description + " with milk"; }
        }
    }
