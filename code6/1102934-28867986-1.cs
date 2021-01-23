    public class Price
    {
        // Instance properties
        public decimal BasePrice { get; set; }
        public decimal PercentMarkup { get; set; }
        public decimal MarkedupPrice { get { return GetMarkedUpPrice(PercentMarkup); } }
        // Instance method to allow you to show additional markup
        // prices without changing the instance property
        public decimal GetMarkedUpPrice(decimal percentMarkup)
        {
            return GetMarkedUpPrice(BasePrice, percentMarkup); 
        }
        // Static method to get a quick calculation without instance overhead
        public static decimal GetMarkedUpPrice(decimal basePrice, decimal percentMarkup)
        {
            return basePrice * (1 + percentMarkup);
        }
    }
