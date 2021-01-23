    [RoutePrefix("v1")]
    public class V1_ProductsController : ApiController
    {
        [Route("products")]
        public IEnumerable<string> Get()
        {
            return new string[] { "v1-product1", "v1-product2" };
        }
         //....
    }
    [RoutePrefix("v2")]
    public class V2_ProductsController : ApiController
    {
         [Route("products")]
        public IEnumerable<string> Get()
        {
            return new string[] { "v2-product1", "v2-product2" };
        }
        //....
    }
