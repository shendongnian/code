    public class Cream : IBeverage
    {
        private readonly IBeverage _beverage;
        public Cream(IBeverage beverage)
        {
            _beverage = beverage;
        }
        public decimal Price
        {
            get { return _beverage.Price + 2M; }
        }
        public string Description
        {
            get { return _beverage.Description + " with cream"; }
        }
    }
