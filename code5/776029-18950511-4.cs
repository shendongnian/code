    public interface IProducts
    {
        int ProductId { get; set; }
        decimal Price { get; set; }
        List<IProductCategories> Categorieses { get; set; }
    }
    public interface IProductCategories
    {
        int ProductId { get; set; }
        string ProductCategoryName { get; set; }
    }
    internal class Products : IProducts
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public List<IProductCategories> Categorieses { get; set; }
    }
    internal class ProductCategories : IProductCategories
    {
        public int ProductId { get; set; }
        public string ProductCategoryName { get; set; }
        public ProductCategories(int productId, string productCategoryName)
        {
            ProductId = productId;
            ProductCategoryName = productCategoryName;
        }
    }
    public class ProductDataContract
    {
        public int ProductId { get; set; }
        public List<IProductCategories> Categorieses { get; set; }
    }
