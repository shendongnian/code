    public class ProductsController : BaseApiController
    {
        [Route("api/{clientUrl}/products")]
        public HttpResponseMessage Get()  {}
    }
    
    public class ProductGroupsController : BaseApiController
    {
        [Route("api/{clientUrl}/products/groups")]
        public HttpResponseMessage Get()    {  }
    }
