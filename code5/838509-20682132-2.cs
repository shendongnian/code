    public class Quote
    {
        public int Id { get; set; }
        public string QuoteNo { get; set; }
        public DateTime Date { get; set; }
    }
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PartNo { get; set; }
    }
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TelNo { get; set; }
    }
    public class QuoteItemSuppliers
    {
        public Quote Quote { get; set; }
        public Item Item { get; set; }
        public Supplier Supplier { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }      
