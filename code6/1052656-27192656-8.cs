    public class Book
    {
        // The initial price.
        public double Price { get; private set; }
        public IPriceCalculator PriceCalculator { get; private set; } 
        public Book(double price, IPriceCalculator priceCalculator)
        {
            Price = price;
            PriceCalculator = priceCalculator;
        }
        public double CalculatePrice()
        {
            return PriceCalculator.CalculatePrice(Price);
        }
    }
