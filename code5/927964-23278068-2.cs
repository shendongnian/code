    public class ProductViewModel
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public ProductViewModel() { }
        public ProductViewModel(Product product)
        {
            this.ID = product.ID;
            this.Description = product.Description;
            this.DisplayName = product.DisplayName;
        }
    }
 
