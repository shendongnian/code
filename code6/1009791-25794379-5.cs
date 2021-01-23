    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public override ToString()
        {
            return String.Format("{0}    ${1}", Name, Price);
        }
    }
