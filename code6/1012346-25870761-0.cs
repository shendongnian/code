    [RoutePrefix("api/{clientUrl}/products")]
    public class ProductsController : BaseApiController
    {
        [Route("")]
        public HttpResponseMessage GetProducts()  {}
    
        [Route("groups")]
        public HttpResponseMessage GetProductGroups()  {}
    }
