    public class Entity
    {
        public int ServiceId { get; set; }
        public decimal Rate { get; set; }
        public int Quantity { get; set; }
        public decimal Total
        {
            get { return Rate * Quantity; }
        }
    }
