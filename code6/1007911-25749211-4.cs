    public class MyController : Controller
    {
        private ProductList list;
        public MyController()
        {
            list = ProductList.GetProductList();
        }       
    }
