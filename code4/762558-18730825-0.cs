    public class BasePrice : IComponent
    {
        private Decimal _cost;
        public decimal GetCost //as a property maybe use Cost with get; set; in IComponent
        {
            get { return _cost; }
            set { _cost = value; }
        }
    }
