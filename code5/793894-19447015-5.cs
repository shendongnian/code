    public class Milk : BeverageDecorator
    {
        public Milk(IBeverage beverage)
            : base(beverage)
        {
        }
        public override string Description
        {
            get
            {
                return base.Description + " with milk";
            }
        }
    }
