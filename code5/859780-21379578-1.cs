    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class Service : IService
    {
        ARserviceEntities de = new ARserviceEntities();
    
        public List<ProductCategory> GetProductCategory()
        {
            var procat = from t in de.ProductCategories select t;
            return procat.ToList();
        }
    }
