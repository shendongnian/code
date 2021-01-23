    public class Item
    {
        public string @Url;
        public string Name;
        public double Price;
        public Item(string @url, string name, double price)
        {
            this.Url = url;
            this.Name = name;
            this.Price = price;
        }
        public void setPrice(Button button)
        {
            this.Price = Convert.ToDouble(button.Text);
        }
        public override string ToString()
        {
            // example: return string.Format("{0} -> {1}", this.Name, this.Price);
            return this.Price;
        }
