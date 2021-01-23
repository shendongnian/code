        public interface IProductRepository 
        {
            IEnumerable<Product> GetProductsByCategoryId(int categoryId);
        }
        class EfProductRepository : IProductRepository
        {
            private readonly ExDbContext db;
            public EfProductRepository(ExDbContext dbContext)
            {
                this.db = dbContext;
            }
            public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
            {
                var productsByCategoryId = this.db
                    .Products
                    .Where(x => x.ProductCategoryId == categoryId)
                    .ToArray();
                return productsByCategoryId;
            }
        }
