    public class Products : List<Product> {
        public Products(IEnumerable<Product> products) : base(products) {
        }
    }
    Products prods = new Products(filterFunc(param, products));
