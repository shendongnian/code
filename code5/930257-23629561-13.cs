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
                    throw new ArgumentException(
                        "Invalid product identifier.");
                }
                
                var user = UserRepository.GetCurrentUser();
                
                if (false == user.CanView(product))
                {
                    throw new UnauthorizedAccessException(
                        "User has insufficient privileges.");
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
