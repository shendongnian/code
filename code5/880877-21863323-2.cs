    namespace BI
    {
        public class LocalStoreBIObject
        {
            public List<Product> GetProducts()
            {
                //Do some BI stuff.
                //Instantiate appropriate DAL object
                return LocalStoreDALObjec.GetProducts(... pass in some BI params);
            }
        }
    }
