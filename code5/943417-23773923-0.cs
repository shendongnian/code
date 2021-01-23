    public class ProductModel
    {
        public ProductModel()
        {
            this.Products = new List<Product>();
            this.ProductsDropdownItems = new List<SelectListItem>();
        }
        public List<Product> Products { get; set; }
        public int SelectedProductID { get; set; }
        public List<SelectListItem> ProductsDropdownItems { get; set; }
    }
