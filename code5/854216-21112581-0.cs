    public class YourModel {
        public IList<QuantityModel> Quantities { get; set; }
    }
    public class QuantityModel {
        [RegularExpression(@"\d+")] // <--- this
        public int Amount { get; set; }
    }
