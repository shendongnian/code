    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ModelNumber { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double NewPrice { get; set; }
        public override int GetHashCode()
        {
            return Id ^ (Name ?? "").GetHashCode() ^ (ModelNumber ?? "").GetHashCode() ^ (Sku ?? "").GetHashCode()^ (Description ?? "").GetHashCode() ^ Price.GetHashCode() ^ NewPrice.GetHashCode();
        }
    }
