    public class ProductController: ApiController
    {
      public ProductResponseModel Get(int productId) 
      {
         var model = new ProductResponseModel{
            Product = ProductRepository.Get(productId);
         };
         model.Attachments = AttachmentRepository.GetList(model.Product.Name);
    
         // I could have flattened out the Product into its properties instead of having a model.Product,
         // but that can be a maintenance problem and requires something like AutoMapper to manage well
         return model;
      }
    
    }
    
    public class ProductResponseModel {
      public Product Product {get;set;}
      public IEnumerable<Attachment> Attachments {get;set;}
    }
