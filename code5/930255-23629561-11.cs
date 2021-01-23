    public class ProductsModule : NancyModule
    {
        public ProductsModule()
            : base("/products")
        {
            Get["/product/{productid}"] = _ => 
            {
                var request = this.Bind<ProductRequest>();
                var product = ProductRepository.GetById(request.ProductId);
                
                if (product == null)
                {
                    var error = new Response();
                    error.StatusCode = HttpStatusCode.BadRequest;
                    error.ReasonPhrase = "Invalid product identifier.";
                    return error;
                }
                
                var user = UserRepository.GetCurrentUser();
                
                if (false == user.CanView(product))
                {
                    var error = new Response();
                    error.StatusCode = HttpStatusCode.Unauthorized;
                    error.ReasonPhrase = "User has insufficient privileges.";
                    return error;
                }
                var productDto = CreateProductDto(product);
                
                var htmlDto = new {
                  Product = productDto,
                  RelatedProducts = GetRelatedProductsDto(product)
                };
                return Negotiate
                        .WithAllowedMediaRange(MediaRange.FromString("text/html"))
                        .WithAllowedMediaRange(MediaRange.FromString("application/json"))
                        .WithModel(htmlDto)  // Model for 'text/html'
                        .WithMediaRangeModel(
                              MediaRange.FromString("application/json"), 
                              productDto); // Model for 'application/json';
            }
        }
    }
