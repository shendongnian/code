    public interface IDiscountStrategy 
    {
        decimal GetDiscount(string userType, decimal orderTotal);
    }
    
    public class DiscountStrategy : IDiscountStrategy
    {
        private readonly IEnumerable<IDiscountCalculator> _discountCalculators;
    
        public DiscountStrategy(IEnumerable<IDiscountCalculator> discountCalculators)
        {
            _discountCalculators = discountCalculators;
        }
    
        public decimal GetDiscount(string userType, decimal orderTotal)
        {
            var calculator = _discountCalculators.FirstOrDefault(x => x.AppliesTo(userType));
            if (calculator == null) return 0;
            return calculator.CalculateDiscount(orderTotal);
        }
    }
    
    public interface IDiscountCalculator
    {
        bool AppliesTo(string userType);
        decimal CalculateDiscount(decimal orderTotal);
    }
    
    public class NormalUserDiscountCalculator : IDiscountCalculator
    {
        public bool AppliesTo(string userType)
        {
            return userType == "Normal";
        }
    
        public decimal CalculateDiscount(decimal orderTotal)
        {
            return orderTotal * 0.1m;
        }
    }
    
    public class SpecialUserDiscountCalculator : IDiscountCalculator
    {
        public bool AppliesTo(string userType)
        {
            return userType == "Special";
        }
    
        public decimal CalculateDiscount(decimal orderTotal)
        {
            return orderTotal * 0.5m;
        }
    }
