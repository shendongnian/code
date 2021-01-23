    public interface IPriceMethod
    {
        double Calculate(IList<double> priceHistorie);
    }
    public class AveragePrice : IPriceMethod
    {
        public double Calculate(IList<double> priceHistorie)
        {
            return priceHistorie.Average();
        }
    }
    // other classes
    public class Article 
    {
        private List<Double> _pricehistorie;
    
        public List<Double> Pricehistorie
        {
            get { return _pricehistorie; }
            set { _pricehistorie = value; }
        }
    
        public IPriceMethod Pricemethod { get; set; }
    
        public double Price
        {
            get {
                return Pricemethod.Calculate(Pricehistorie);
            }
        }
    
    }
