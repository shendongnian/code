    public class NameAndPrice
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public override string ToString()
        {
            return String.Format("{0}: {1:c}", Name, Price);
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
    NameAndPrice a = new NameAndPrice() { Name = "Hello", Price = 1.25d };
    comboBox1.Items.Add(a);
