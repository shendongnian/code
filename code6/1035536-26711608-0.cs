    public class ProductsController : ApiController
    {
        public IEnumerable<ProductDTO> Get(ODataQueryOptions<ProductDTO> q)
        {
            IQueryable<Product> products = this._products.AsQueryable();
            IEdmModel model = GetModel();
            IEdmType type = model.FindDeclaredType("TestAPI.Models.Product");
            IEdmNavigationSource source = model.FindDeclaredEntitySet("Products");
            ODataQueryOptionParser parser = new ODataQueryOptionParser(model, type, source, new Dictionary<string, string> { { "$filter", q.Filter.RawValue } });
            ODataQueryContext context = new ODataQueryContext(model, typeof(Product), q.Context.Path);
            FilterQueryOption filter = new FilterQueryOption(q.Filter.RawValue, context, parser);
            if (filter != null) products = filter.ApplyTo(products, new ODataQuerySettings()) as IQueryable<Product>;
            return products.Select(p => new ProductDTO(p));
        }
    }
