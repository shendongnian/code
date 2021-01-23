    public partial class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
    		OnCreated();
        }
    	partial void OnCreated();
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Product> Products { get; set; }
    }
