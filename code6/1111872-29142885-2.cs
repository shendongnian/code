    public partial class ProdCategory
    {
        protected ProdCategory() {} //protected default constructor is required by EF
        public ProdCategory(Category category, Product product)
        {
            this.Category = category;
            this.Product = product;
            this.ProdID = product.Id;
            this.CategoryID = category.Id;
        }
        public long ProdID { get; protected set; }
        public int CategoryID { get; protected set; }
        public bool PermanentlyDelete { get; set; }
        public System.DateTime DateCreated { get; set; }
    
        public virtual Category Category { get; protected set; }
        public virtual Product Product { get; protected set; }
    }
