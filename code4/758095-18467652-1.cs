    namespace Uppgift_1.Models
    {
        public interface IProduct
        {
            IQueryable<Product> GetProducts();
        }
    }
