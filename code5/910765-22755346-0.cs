    public interface IProductDal
    {
        void DeleteProduct(int id);
    }
    public class MyService
    {
        private IProductDal _productDal;
        public MyService(IProductDal productDal)
        {
            if (productDal == null) { throw new ArgumentNullException("productDal"); }
            _productDal = productDal;
        }
        public void DeleteProduct(int id)
        {
            _productDal.DeleteProduct(id);
        }
    }
