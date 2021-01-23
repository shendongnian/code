    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class Service : IService
    {
        ARserviceEntities de = new ARserviceEntities();
    
        [WebInvoke(UriTemplate = "/Print", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        public List<ProductCategory> GetProductCategory()
        {
            var procat = from t in de.ProductCategories select t;
            return procat.ToList();
        }
    }
