    public interface IPriceCalculator
    {
         public double CalculatePrice(double price);
    }
    public class PriceCalculator
    {
        public double Discount { get; private set; }
        public PriceCalculator(double discount)
        {
            Discount = discount;
        }
        public double CalculatePrice(double price)
        {
            return price - (price*Discount)
        }
    }
    
