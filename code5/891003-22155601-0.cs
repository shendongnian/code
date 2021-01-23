    namespace SportsStore.Domain.Abstract
    {
        public interface IProductRepository
        {
            IEnumerable<Product> Products { get; /*set;*/ }
        }
    }
