    pulbic class Fruits
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
        public override ToString()
        {
            return String.Format("Name: {0}, Weight: {1}, Quantity: {2}",item.Name, item.Weight, item.Quantity);
        }
    }
