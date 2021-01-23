    public class Fruits
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public int Quantity { get; set; }
        public Fruits(string name, double weight, int quantity)
        {
           Name = name;
           Weight = weight;
           Quantity = quantity;
        }
        public string override ToString()
        {
            return String.Format("Name: {0}, Weight: {1}, Quantity: {2}", Name, Weight, Quantity);
        }
    }
