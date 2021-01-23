    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        [Route("foo")]
        [Route("")]
        public IEnumerable<Product> GetAllProducts(){}
    }
