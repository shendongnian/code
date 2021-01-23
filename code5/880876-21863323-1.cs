    namespace MyUIName.Services
    {
        public class ProductServiceAgent : BaseServiceAgent, IProductServiceAgent
        {
            //Contract implementation
            public List<Product> GetProducts()
            {
                if (Settings.Default.StoreType == "Local")
                {
                    LocalStoreBIObject = new...
                    LocalStoreBIObject.GetProducts();
                }
                if (Settings.Default.StoreType == "Remote")
                {
                    RemoteStoreBIObject = new...
                    RemoteStoreBIObject.GetProducts();
                }
            }
        }
    }
