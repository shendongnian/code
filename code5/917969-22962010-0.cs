     public class ProductController 
     {
           private IProductService productService;
           private ICategoryService categoryService;
    
           public ProductController(IProductService productService, 
                                    ICategoryService categoryService)
           {
               this.productService = productService;
               this.categoryService = categoryService;
           }
      }
