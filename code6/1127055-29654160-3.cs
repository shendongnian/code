    public class ProductViewModel
    {
        // This shouldn't be here, only fields that you need from Product should be here and mapped within your controller action
        //public Product Product { get; set; }
    
        // This should be a view model, used for the view only and not used as a database model too!
        public List<ProductDetailViewModel> ProductDetails { get; set; }
    }
