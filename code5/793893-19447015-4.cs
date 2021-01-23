    public abstract class BeverageDecorator : IBeverage
    {
        private readonly IBeverage _beverage;
        public BeverageDecorator(IBeverage beverage)
        {
            _beverage = beverage;
        }
        public virtual decimal Price
        {
            get { return _beverage.Price; }
        }
        public virtual string Description
        {
            get { return _beverage.Description; }
        }
    }
