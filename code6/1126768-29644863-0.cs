	public class ProductController : Controller
    {
        public List<Product> ProductsList {
				get { 
					var products = (Session['ProductsList'] as List<Product>);
					if(products == null)
					{
					    products = ProductManager.ReadProducts();
						Session['ProductsList'] = products;
					}
					
					return products;
				}
			}
        // actions
    }
	
