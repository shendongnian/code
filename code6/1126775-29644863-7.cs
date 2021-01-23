	public class ProductController : Controller
    {
        public List<Product> ProductsList {
				get { 
					var products = (HttpRuntime.Cache['ProductsList'] as List<Product>);
					if(products == null)
					{
					    products = ProductManager.ReadProducts();
						HttpRuntime.Cache['ProductsList'] = products;
					}
					
					return products;
				}
			}
        // actions
    }
	
