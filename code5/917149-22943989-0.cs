    public class ModelBase : EntityData, INotifyPropertyChanged
    {
        // implementation of INPC omitted
    }
    
    public class Product : ModelBase
    {
        /// <summary>
        /// The name.
        /// </summary>
        private string name;
    
        /// <summary>
        /// The price.
        /// </summary>
        private double price;
    
        // other properties omitted for brevity
    
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]   
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                this.RaisePropertyChanged("Name");
            }
        }
    
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        [JsonProperty("price")]   
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                this.price = value; 
                this.RaisePropertyChanged("Price");
            }
        }
    }
    
    public class ProductController : TableController<Product>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            var context = new TheContextClassInYourService(this.Services.Settings.Schema);
            this.DomainManager = new EntityDomainManager<Product>(context, this.Request, this.Services);
        }
    
        public IQueryable<Product> GetAll()
        {
            return base.Query();
        }
    
        public SingleResult<Product> GetOneProduct(string id)
        {
            return base.Lookup(id);
        }
    
        // insert
        public Task<Product> PostProduct(Product input)
        {
            return base.InsertAsync(input);
        }
    
        // update
        public Task<Product> PatchProduct(string id, Delta<Product> patch)
        {
            return base.UpdateAsync(id, patch);
        }
    
        public Task DeleteProduct(string id)
        {
            return base.DeleteAsync(id);
        }
    }
