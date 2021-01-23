    public class ProductsController : ApiController
    {
        [EnableQuery]
        IQueryable<Product> Get() {}
    }
