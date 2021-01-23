    public class Product
    {
        private double _price;
        [Range(0M, Double.MaxValue)]
        public double Price {
            get {
               return _price;
            }
            set {
                if (value <= 0M) {
                    throw new ArgumentOutOfRangeException("value",
                            "The value must be greater than 0.0");
                }
                _price = value;
            }
        }
    }
