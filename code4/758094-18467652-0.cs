    public class MyRepository : IProduct
    {
        public IQueryable<Product> Products
        {
            get { return MYcontext.pList; }
        }
        
        public IQueryable<Product> GetProducts() {
            return (from obj in Products select obj).FirstOrDefault();
      }
    }
