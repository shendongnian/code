    public class Fruit
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public int Quantity { get; set; }
        public Fruit(string name, double weight, int quantity)
        {
           Name = name;
           Weight = weight;
           Quantity = quantity;
        }
        public override string ToString()
        {
            return String.Format("Name: {0}, Weight: {1}, Quantity: {2}", Name, Weight, Quantity);
        }
    }
