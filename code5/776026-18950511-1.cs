    public interface IProducts
    {
        string ProductName { get; set; }
    }
    public interface IProductCategories
    {
        string CategoryName { get; set; }
        List<IProducts> Products { get; set; }
    }
    public class ProductCategories : IProductCategories
    {
        public string CategoryName { get; set; }
        public List<IProducts> Products { get; set; }
    }
    class Products : IProducts
    {
        public string ProductName { get; set; }
    }
    class ProductCategoryDataContract
    {
        public int ProductCategoryId;
        public string ProductCategoryName;
        public List<IProducts> Products;
    }
