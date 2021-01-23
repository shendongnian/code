    namespace DAL
    {
        public class LocalStoreDALObject
        {
            public List<Product> GetProducts()
            {
                using (var localStoreContex = new...)
                {
                    return localStoreContext.Products.Where(p => p... some logic);
                }
            }
        }
    }
