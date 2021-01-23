    public class ProductWithSupplier // this should be ProductWithSuppliers I guess.
    {
        public Product Products { get; set; }
        public IEnumerable<Supplier> Suppliers { get; set; }
    }
